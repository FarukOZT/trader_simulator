//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class CoinListUI : MonoBehaviour
//{
//    public GameObject Panel; // Panel prefab referansý
//    public Transform contentParent; // ScrollView içindeki Content objesi
//    private CoinMarketManager coinMarketManager; // CoinManager referansý

//    void Start()
//    {
//        // CoinManager'i bul
//        coinMarketManager = FindObjectOfType<CoinMarketManager>();

//        // Coin bilgilerini UI'ya ekle
//        UpdateUI();
//    }

//    // Coin bilgilerini UI'da göster
//    public void UpdateUI()
//    {
//        // Eski UI öðelerini temizle
//        void UpdateUI()
//        {
//            foreach (var coin in coins)
//            {
//                coin.uiText.text = $"{coin.Name}: {coin.CurrentValue:F2}"; // Deðeri güncelle
//            }
//        }

//        // Yeni UI öðelerini oluþtur
//        List<Coin> coins = coinMarketManager.Coins;
//        foreach (var coin in coins)
//        {
//            // Panel prefab'ýndan yeni bir obje oluþtur
//            GameObject panelGO = Instantiate(Panel, contentParent);

//            // Panel içindeki Text bileþenlerini bul ve doldur
//            Text[] texts = panelGO.GetComponentsInChildren<Text>();
//            texts[0].text = coin.Name; // Ýlk Text: Coin ismi
//            texts[1].text = $"{coin.Value:F2}"; // Ýkinci Text: Coin deðeri
//        }
//    }
//}
