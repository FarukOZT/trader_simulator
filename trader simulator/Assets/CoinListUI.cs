//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class CoinListUI : MonoBehaviour
//{
//    public GameObject Panel; // Panel prefab referans�
//    public Transform contentParent; // ScrollView i�indeki Content objesi
//    private CoinMarketManager coinMarketManager; // CoinManager referans�

//    void Start()
//    {
//        // CoinManager'i bul
//        coinMarketManager = FindObjectOfType<CoinMarketManager>();

//        // Coin bilgilerini UI'ya ekle
//        UpdateUI();
//    }

//    // Coin bilgilerini UI'da g�ster
//    public void UpdateUI()
//    {
//        // Eski UI ��elerini temizle
//        void UpdateUI()
//        {
//            foreach (var coin in coins)
//            {
//                coin.uiText.text = $"{coin.Name}: {coin.CurrentValue:F2}"; // De�eri g�ncelle
//            }
//        }

//        // Yeni UI ��elerini olu�tur
//        List<Coin> coins = coinMarketManager.Coins;
//        foreach (var coin in coins)
//        {
//            // Panel prefab'�ndan yeni bir obje olu�tur
//            GameObject panelGO = Instantiate(Panel, contentParent);

//            // Panel i�indeki Text bile�enlerini bul ve doldur
//            Text[] texts = panelGO.GetComponentsInChildren<Text>();
//            texts[0].text = coin.Name; // �lk Text: Coin ismi
//            texts[1].text = $"{coin.Value:F2}"; // �kinci Text: Coin de�eri
//        }
//    }
//}
