public static class Constants
{
    //This is not a constant, but its easier to keep this value here.
    public static string WALLET = "";
    public static string ENS = "";

    //Wallet states.
    public const int WALLET_NONE = 0;
    public const int WALLET_METAMASK = 1;
    public const int WALLET_WALLETCONNECT = 2;
    public const int WALLET_GME = 3;


    //Required for API calls for NFT data and pinging ethereum smart contract
    public const string TOKENCONTRACT = "";
    public const string IPFSNODE = "https://monster.mypinata.cloud/ipfs/"; //Set to public node, set to private for better perfomance


    //Scenes.
    public const string SCENE_LOGIN = "Login"; //Landing Page
    public const string SCENE_UNLOCK = "Unlock"; //Unlock and authentication Page
    public const string SCENE_MAIN = "Main"; //Main Page


    //Users NFT data
    public static TokenJson Tokens;


}

