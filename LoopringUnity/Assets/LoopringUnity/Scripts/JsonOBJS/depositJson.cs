[System.Serializable]
public class depositJson
{
    public string totalNum;
    public Deposits[] deposits;


}

[System.Serializable]
public class Deposits
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
    public string depositFrom;
    public int depositFromAccountId;
    public BlockedInfo[] blockIdInfo;
    public StorageInfo[] storageInfo;
}
