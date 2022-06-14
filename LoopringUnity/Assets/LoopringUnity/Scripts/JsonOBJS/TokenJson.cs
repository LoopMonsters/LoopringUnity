using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class TokenJson
{
    public string totalNum;
    public Data[] data;


}

[System.Serializable]
public class Data
{
    public string accountId;
    public string tokenId;
    public string nftData;
    public string tokenAddress;
    public string nftId;
    public string total;
    public string locked;
    public string pending;
    public string withdraw;
    public string deposit;
}


