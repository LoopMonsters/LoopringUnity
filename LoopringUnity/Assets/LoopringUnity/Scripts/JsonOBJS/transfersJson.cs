[System.Serializable]
public class transfersJson
{
    public string totalNum;
    public Transfers[] transfers;


}

[System.Serializable]
public class Transfers
{
    public string id;
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
    public int payeeId;
    public string payeeAddress;
    public BlockedInfo[] blockIdInfo;
    public StorageInfo[] storageInfo;
}
