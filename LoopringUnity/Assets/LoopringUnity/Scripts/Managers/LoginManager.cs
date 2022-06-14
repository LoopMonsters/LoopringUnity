using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WalletConnectSharp.Unity;

public class LoginManager : MonoBehaviour
{    
    public GameObject panel_Metamask;
    public GameObject panel_Walletconnect;

    // Start is called before the first frame update
    void Start()
    {
        panel_Metamask.SetActive(true);
        panel_Walletconnect.SetActive(false);
    }

    private void Update()
    {
        if (Constants.WALLET != "")
        {
            
            SceneManager.LoadScene("Unlock");
        }
        if (panel_Walletconnect.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Button_Metamask();
            }
        }
    }
    async public void Button_GME()
    {
        await WalletConnector.ConnectToWeb3Wallet("gme");
        StateMachine.SetWallet(Constants.WALLET_GME);
    }
    async public void Button_MM()
    {
        await WalletConnector.ConnectToWeb3Wallet("m");
        StateMachine.SetWallet(Constants.WALLET_METAMASK);

    }
    public void Button_Metamask()
    {
        panel_Metamask.SetActive(true);
        panel_Walletconnect.SetActive(false);
    }
    public void Button_WalletConnect()
    {
        panel_Metamask.SetActive(false);
        panel_Walletconnect.SetActive(true);
    }

    public void WalletConnectConnected()
    {
        Constants.WALLET = WalletConnect.ActiveSession.Accounts[0].ToString();
        StateMachine.SetWallet(Constants.WALLET_WALLETCONNECT);
        SceneManager.LoadScene(Constants.SCENE_UNLOCK);
    }
}
