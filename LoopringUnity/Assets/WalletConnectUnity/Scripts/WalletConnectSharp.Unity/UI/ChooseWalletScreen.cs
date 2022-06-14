using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace WalletConnectSharp.Unity.UI
{
    public class ChooseWalletScreen : MonoBehaviour
    {
        public WalletConnect WalletConnect;
        public GameObject buttonPrefab;
        public Transform buttonGridTransform;
        public Text loadingText;
        
        private void Start()
        {
            StartCoroutine(BuildWalletButtons());
        }

        private IEnumerator BuildWalletButtons()
        {
            yield return WalletConnect.FetchWalletList();

            foreach (var walletId in WalletConnect.SupportedWallets.Keys)
            {
                var walletData = WalletConnect.SupportedWallets[walletId];

                var walletObj = Instantiate(buttonPrefab, buttonGridTransform);

                var walletImage = walletObj.GetComponent<Image>();
                var walletButton = walletObj.GetComponent<Button>();

                walletImage.sprite = walletData.medimumIcon;
                
                walletButton.onClick.AddListener(delegate
                {
                    WalletConnect.OpenDeepLink(walletData);
                });
            }
            
            Destroy(loadingText.gameObject);
        }
    }
}