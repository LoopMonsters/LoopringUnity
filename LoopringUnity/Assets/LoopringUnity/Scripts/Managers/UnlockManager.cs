using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Threading.Tasks;
using System.Numerics;
using PoseidonSharp;
using WalletConnectSharp.Unity;

public class UnlockManager : MonoBehaviour
{

    //Adds UI Gameobjects from the scene.
    public Text text_Wallet;
    public Button button_Unlock;
    public Button button_Proceed;


    //Creates an object of the API caller class, so we can make API calls.
    APICaller m_cli;

    //Querying Looprings API returns a JSON, the responses are stored as an object (JsonOBJS folder).
    apiKeyJson m_ApiKey;
    accountJson m_Account;
    TokenJson m_Tokens;
    resolvedENS m_ens;

    async void Start()
    {
        //Creates new object to hold users L2 NFTs.
        m_Tokens = new TokenJson();

        //Sets up buttons on Unlock scene.
        button_Unlock.interactable = true;
        button_Proceed.interactable = false;



        //If a wallet is connected, it will display it at the top of the scene.
        //If you have a Loopring ENS, that will display instead.
        if (StateMachine.currentWallet != Constants.WALLET_NONE)
        {
            //Adds an API caller script to the object and sets m_cli to it.
            m_cli = gameObject.AddComponent<APICaller>();
            //Query user account
            await SetAccount();
            //Sets Text at top to Wallet Address.
            text_Wallet.text = Constants.WALLET; //Constants.WALLET set in SetAccount().
            //Query for a Loopring ENS
            await SetENS();
            //If the account has a Loopring ENS, it sets the text at the top to the ENS
            if (Constants.ENS != "")
            {
                text_Wallet.text = Constants.ENS;
            }
        }
        else
        {
            //This displays if the Unlock page is access without connecting a wallet.
            button_Unlock.interactable = false;
            text_Wallet.text = "Sneaky sneaky! You need to connect an account first!";
        }

    }

    //UI Button functions:

    public async void UnlockButton()
    {
        //Signs Unlock Message.
        await SignMessageFunction();

        //Changes Button Text to "Unlocked" when signed (doesnt verify signature).
        button_Unlock.GetComponentInChildren<Text>().text = "Unlocked";

        button_Unlock.interactable = false;
        //Gets Users NFT data after it has unlocked.
        await GetTokens();
        button_Proceed.interactable = true;

    }
    public void ProceedButton()
    {
        SceneManager.LoadScene("Main");
    }



    //All API calls and Queries below:

    async Task SignMessageFunction()
    {
        try
        {
            //Keyseed is manually set as a string as sometimes
            //m_Account.keySeed is null. Not sure why, may be an await/async issue.
            string _keyseedMsg = "Sign this message to access Loopring Exchange: 0x0BABA1Ad5bE3a5C0a66E7ac838a129Bf948f1eA4 with key nonce: 0";

            //Sets empty string to hold the response of the signed message.
            string response = "";

            
            //Checks which wallet the user has, as WalletConnect has a different signing method,
            //and then signs the keySeed message.
            switch (StateMachine.currentWallet)
            {
                case Constants.WALLET_METAMASK:
                    response = await WalletConnector.SignWeb3Message("m", Constants.WALLET, _keyseedMsg);
                    break;
                case Constants.WALLET_WALLETCONNECT:
                    response = await PersonalSignWALLETCONNECT(_keyseedMsg);
                    break;
                case Constants.WALLET_GME:
                    response = await WalletConnector.SignWeb3Message("gme", Constants.WALLET, _keyseedMsg);
                    break;
            }

            //The response is an ECDSA signature, for L2 we need EDDSA,
            //GetApiKeyEDDSASig returns an EDDSA signature from taking in the ECDSA sig,
            //Be aware it is only tailored for getting the Loopring API key.
            await GetApiKey(GetApiKeyEDDSASig(response));

        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    public async Task SetAccount()
    {
        //Queries the user account
        m_Account = await m_cli.GetAccountIDTask<accountJson>(Constants.WALLET);
    }

    public async Task SetENS()
    {
        //Queries for Loopring ENS
        m_ens = await m_cli.ResolveEns<resolvedENS>(Constants.WALLET);

        //If m_ens.data is not null or empty, Constants.ENS gets it value.
        if(m_ens.data !=null || m_ens.data != "")
        {
            Constants.ENS = m_ens.data;
        }

    }

    async Task GetTokens()
    {
        //Queries user NFT data
        m_Tokens = await m_cli.GetTokenBalance<TokenJson>(m_Account.accountId, PlayerPrefs.GetString("APIKEY"), "0x33af5f2a46d8132ca7d948ee51ba156b1aca1bcd");

        //If m_Tokens.data is not null or empty, Constants.Tokens gets it value.
        if (m_Tokens.data != null)
        {
            Constants.Tokens = m_Tokens;

            //This can be deleted, but here you can cycle through all of the queried NFTs
            foreach (Data d in m_Tokens.data)
            {      
               Debug.Log(m_Tokens.data[0].nftData);
            }
        }
    }

    async Task GetApiKey(string _xapisig)
    {
        //Queries users API Key
        m_ApiKey = await m_cli.GetAPIKey<apiKeyJson>(m_Account.accountId, _xapisig);


        if (m_ApiKey.apiKey == "" || m_ApiKey.apiKey == null)
        {
            Debug.Log("Failed to get API key check response");
        }
        else
        {
            //If successful, it is stored in PlayerPrefs (but cleared in next scene).
            PlayerPrefs.SetString("APIKEY", m_ApiKey.apiKey);
        }

    }

    //Sign a message with WalletConnect
    public async Task<string> PersonalSignWALLETCONNECT(string message, int addressIndex = 0)
    {
        var address = WalletConnect.ActiveSession.Accounts[addressIndex];
        var results = await WalletConnect.ActiveSession.EthPersonalSign(address, message);

        return results;
    }

    //This function takes an ECDSA signature, uses Fudgeys PoseidonSharp
    //to get an EDDSA signature. See PosedionHelper.cs
    public string GetApiKeyEDDSASig(string _signedEcDSA)
    {
        var _keyDeets = PoseidonHelper.GetL2PKFromMetaMask(_signedEcDSA);

        string _api_signatureBase = "GET&https%3A%2F%2Fapi3.loopring.io%2Fapi%2Fv3%2FapiKey&accountId%3D" + m_Account.accountId;
        BigInteger _sigbaseToBitInt = SHA256Helper.CalculateSHA256HashNumber(_api_signatureBase);
        Eddsa eddsa = new Eddsa(_sigbaseToBitInt, _keyDeets.secretKey); //Put in the calculated poseidon hash in order to Sign
        string signedMessage = eddsa.Sign();


        return signedMessage;
    }
}
