using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

#if UNITY_WEBGL
public class WalletConnector
{
    [DllImport("__Internal")]
    private static extern void connectToWallet(string walletName);
    [DllImport("__Internal")]
    private static extern void OurSignMessage(string wallet, string account, string msg);
    [DllImport("__Internal")]
    private static extern string getAccount();
    [DllImport("__Internal")]
    private static extern string getSignature();

    async public static Task ConnectToWeb3Wallet(string walletName)
    {
        connectToWallet(walletName);
        string wallet = "";
        while (wallet == "")
        {
            await new WaitForSeconds(1f);
            Debug.Log("waiting for wallet");
            wallet = getAccount();
            Debug.Log($"Wallet = {wallet}");
        }
        Constants.WALLET = wallet;
        Debug.Log($"Wallet = {Constants.WALLET}");
    }
    async public static Task<string> SignWeb3Message(string walletName, string acc, string message)
    {
        OurSignMessage(walletName, acc, message);
        string sig = "";
        while(sig == "")
        {
            await new WaitForSeconds(1f);
            Debug.Log("waiting for sig");
            sig = getSignature();
            Debug.Log($"sig = {sig}");
        }
            
        return sig;
    }
}
#endif