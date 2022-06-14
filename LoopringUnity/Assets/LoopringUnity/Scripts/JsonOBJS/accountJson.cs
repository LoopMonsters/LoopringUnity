using System.Collections;
using System.Collections.Generic;


[System.Serializable]


public class pKey
{
    public string x;
    public string y;
}
public class accountJson
{


    public string accountId;
    public string owner;
    public bool frozen;
    public pKey publicKey;
    public string keySeed;
    public int nonce;
    public int keyNonce;


}
