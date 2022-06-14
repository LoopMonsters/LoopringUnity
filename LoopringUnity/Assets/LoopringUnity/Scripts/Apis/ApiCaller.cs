using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;


public class APICaller : MonoBehaviour
{
    /*
    This has an m_ApiEndpont variable which points to Looprings API,
    I kept making mistakes like a donut when making the var _urls in the
    requests below, so somtimes I manually put in the string.

    */
    public string m_ApiEndpoint = "https://api3.loopring.io/api/v3/";

    public async Task<TResultType> GetAPIKey<TResultType>(string _id, string _response)
    {
        string _json;

        var _url = m_ApiEndpoint + "apiKey?accountId=" + _id;
        using var _www = UnityWebRequest.Get(_url);

        _www.SetRequestHeader("X-API-SIG", _response);

        var _operation = _www.SendWebRequest();
        while (!_operation.isDone)
        {
            await Task.Yield();
        }

        if (_www.result == UnityWebRequest.Result.Success)
        {
            _json = _www.downloadHandler.text;
            var _result = JsonUtility.FromJson<TResultType>(_json);
            Debug.Log("success");
            return _result;
        }
        else
        {

            return default;
        }
    }

    public async Task<TResultType> GetAccountIDTask<TResultType>(string _wallet)
    {
        string _json;
        var _url = m_ApiEndpoint + "account?owner=" + _wallet;
        using var _www = UnityWebRequest.Get(_url);
        _www.SetRequestHeader("Content-Type", "application/json");
        var _operation = _www.SendWebRequest();

        while (!_operation.isDone)
        {
            await Task.Yield();
        }

        if (_www.result == UnityWebRequest.Result.Success)
        {
            _json = _www.downloadHandler.text;
            var _result = JsonUtility.FromJson<TResultType>(_json);
            Debug.Log("success");
            return _result;
        }
        else
        {
            return default;
        }
    }


    public async Task<TResultType> GetTokenBalance<TResultType>(string _accId, string _apiKey, string _tokenAddrs)
    {
        string _json;
        var _url = m_ApiEndpoint + "user/nft/balances?accountId=" + _accId + "&tokenAddrs=" + _tokenAddrs + "&limit=100";// + "&nftDatas=" + _nftDatas;
        using var _www = UnityWebRequest.Get(_url);
        _www.SetRequestHeader("Content-Type", "application/json");
        _www.SetRequestHeader("X-API-KEY", _apiKey);
        var _operation = _www.SendWebRequest();
        while (!_operation.isDone)
        {
            await Task.Yield();
        }

        if (_www.result == UnityWebRequest.Result.Success)
        {
            _json = _www.downloadHandler.text;
            var _result = JsonUtility.FromJson<TResultType>(_json);
            //Debug.Log("success");
            return _result;
        }
        else
        {
            return default;
        }
    }

    public async Task<TResultType> ResolveEns<TResultType>(string _walletAddrs)
    {
        string _json;
        var _url = "https://api3.loopring.io/api/wallet/v3/resolveName?owner=" + _walletAddrs;   // + "&nftDatas=" + _nftDatas;
        using var _www = UnityWebRequest.Get(_url);
        _www.SetRequestHeader("Content-Type", "application/json");
        var _operation = _www.SendWebRequest();
        while (!_operation.isDone)
        {
            await Task.Yield();
        }

        if (_www.result == UnityWebRequest.Result.Success)
        {
            _json = _www.downloadHandler.text;
            var _result = JsonUtility.FromJson<TResultType>(_json);
            //Debug.Log("success");
            return _result;
        }
        else
        {
            return default;
        }
    }
    public async Task<TResultType> GetMetadata<TResultType>(string _metadataIpfs)
    {

        
        string _json;
        var _url = Constants.IPFSNODE + _metadataIpfs;
        using var _www = UnityWebRequest.Get(_url);
 

        var _operation = _www.SendWebRequest();
        while (!_operation.isDone)
        {
            await Task.Yield();
        }

        if (_www.result == UnityWebRequest.Result.Success)
        {
            _json = _www.downloadHandler.text;
            var _result = JsonUtility.FromJson<TResultType>(_json);
           // Debug.Log("successfully loaded metadata.json");
            return _result;
        }
        else
        {
            return default;
        }
    }
}