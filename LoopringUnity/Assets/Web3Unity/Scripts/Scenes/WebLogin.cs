using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_WEBGL
public class WebLogin : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Web3Connect();

    [DllImport("__Internal")]
    private static extern string ConnectAccount();

    [DllImport("__Internal")]
    private static extern void SetConnectAccount(string value);

    private int expirationTime;
    private string account; 

    public void OnLogin()
    {
        Web3Connect();
        OnConnected();
    }

    async private void OnConnected()
    {
        account = ConnectAccount();
        while (account == "") {
            await new WaitForSeconds(1f);
            account = ConnectAccount();
        };
        // save account for next scene
        PlayerPrefs.SetString("Account", account);
        Constants.WALLET = account;
        StateMachine.SetWallet(Constants.WALLET_METAMASK);
        // reset login message
        SetConnectAccount("");
        // load next scene
        SceneManager.LoadScene(Constants.SCENE_UNLOCK);
    }

    public void OnSkip()
    {
        // burner account for skipped sign in screen
        PlayerPrefs.SetString("Account", "");
        StateMachine.SetWallet(Constants.WALLET_NONE);
        // move to next scene
        SceneManager.LoadScene(Constants.SCENE_UNLOCK);
    }
}
#endif
