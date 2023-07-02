using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MainPageManager : MonoBehaviour
{
    private string m_ApiKey = "";

    public Text text_wallet;
    public Text text_apiKey;

    void Start()
    {
        //Sets API Key to private variable
        m_ApiKey = PlayerPrefs.GetString("APIKEY");
        PlayerPrefs.SetString("APIKEY", "");

        text_wallet.text = Constants.WALLET;
        text_apiKey.text = "API Key (first 8 chars):   " + m_ApiKey.Substring(0, 8) + "******************";

        //API Key stuff is mainly used in the UnlockManager, unless you need to use it
        //here, it is better to be safe and clear it. You can always query it again if
        //you need to.
        m_ApiKey = "";
    }

}
