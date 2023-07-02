[System.Serializable]
public class withdrawalJson
{
    public string totalNum;
    public Withdrawls[] withdrawals;


}

[System.Serializable]
public class Withdrawls
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
    public string recipient;
    public string distributeHash;
    public string fastWithdrawStatus;
    public bool isFast;
    public BlockedInfo[] blockIdInfo;
    public StorageInfo[] storageInfo;
}
[System.Serializable]
public class StorageInfo
{
    public int accountId;
    public int tokenId;
    public int storageId;

}

[System.Serializable]
public class BlockedInfo
{
    public int blockId;
    public int indexInBlock;

}