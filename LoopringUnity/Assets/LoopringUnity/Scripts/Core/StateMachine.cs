public static class StateMachine
{
    //Current state -> See Constants.cs 
    //(I know its a bad setup, it was easier for me to manage, you can move the States here if its easier).
    public static int currentWallet = 0;


    //Sets the State
    public static void SetWallet(int _WALLET)
    {
        currentWallet = _WALLET;
    }
}

/*      State Machine Template
 *      switch (StateMachine.currentWallet)
        {
            case Constants.WALLET_NONE:
                break;
            case Constants.WALLET_METAMASK:
                break;
            case Constants.WALLET_WALLETCONNECT:
                break;
            case Constants.WALLET_GME:
                break;
        }
*/