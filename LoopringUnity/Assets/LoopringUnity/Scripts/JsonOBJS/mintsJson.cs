[System.Serializable]
public class mintsJson
{
    public string totalNum;
    public Mints[] mints;


}

[System.Serializable]
public class Mints
{
    public int id;
    public int requestId;
    public string hash;
    public string txHash;
    public int accountId;
    public string owner;
    public string status;
    public string nftData;
    public string amount;
    public string feeTokenSymbol;
    public string feeAmount;
    public int createdAt;
    public int updatedAt;
    public string memo;
    public int minterId;
    public string minterAddress;
    public BlockedInfo[] blockIdInfo;
    public StorageInfo[] storageInfo;
}
