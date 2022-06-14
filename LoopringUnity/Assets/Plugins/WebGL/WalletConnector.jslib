var WalletConnector = {
    connectToWallet: function(wallet) {
        var Wallet = null;
        wallet = Pointer_stringify(wallet)
        switch(wallet){
            case 'gme':
                Wallet = window.gamestop;
            break;
            case 'm':
                Wallet = window.ethereum;
            break;
            default:
                window.alert("Wallet not set!");
        }
        if(!Wallet) return;

        Wallet.request({method: "eth_requestAccounts"}).then(function(res){
            window.WCaccount = res[0];
        });
    },
    getAccount: function(){
        if(!window.WCaccount) {
            var returnStr = '';
            var bufferSize = lengthBytesUTF8(returnStr) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(returnStr, buffer, bufferSize)
            return buffer;
        }
        var returnStr = window.WCaccount;
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    getSignature: function(){
        if(!window.WCsignature) {
            var returnStr = '';
            var bufferSize = lengthBytesUTF8(returnStr) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(returnStr, buffer, bufferSize)
            return buffer;
        }
        var returnStr = window.WCsignature;
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize)
        return buffer;
    },
    OurSignMessage: function(wallet, account, message) {
        var Wallet = null;
        wallet = Pointer_stringify(wallet)
        account = Pointer_stringify(account)
        message = Pointer_stringify(message)
        switch(wallet){
            case 'gme':
                Wallet = window.gamestop;
            break;
            case 'm':
                Wallet = window.ethereum;
            break;
            default:
                window.alert("Wallet not set!")
        }
        if(!Wallet) return;

        Wallet.request({ method: 'personal_sign', params: [message, account] }).then(function(res){
            window.WCsignature = res;
        });
    }
}
mergeInto(LibraryManager.library, WalletConnector);