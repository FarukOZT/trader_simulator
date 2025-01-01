using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class CoinMarketManager : MonoBehaviour
{
    public TextMeshProUGUI balanceText;  // Balance text
    public TextMeshProUGUI[] coinValueTexts = null;  // Coin deðerlerini gösterecek text'ler
    public TextMeshProUGUI[] coinNameTexts;  // Coin isimlerini gösterecek text'ler (yeni ekledim)
    private float[] coinValues;  // 10 coin için deðerler
    private string[] coinNames;  // 10 coin için isimler
    public InputField quantityInputField;  // Kullanýcýnýn gireceði miktar

    private float balance = 100f;  // Baþlangýç bakiyesi (örnek)
    private int[] ownedCoins = new int[10];  // Kullanýcýnýn sahip olduðu coin sayýsý
    private int selectedCoinIndex = -1; // Hiçbir coin seçilmediyse -1.

    void Start()
    {
        // Coin isimlerini ve deðerlerini baþlat
        InitializeCoinNames();
        InitializeCoinValues();

        // Balance'ý ekrana yazdýr
        balanceText.text = "$" + balance.ToString("F2");

        // Coin deðerlerini ekrana yazdýr
        DisplayCoinValues();
        int length = Mathf.Min(coinNames.Length, coinNameTexts.Length, coinValues.Length);
        // Coin deðerlerini her 30 saniyede bir güncelle
        StartCoroutine(UpdateCoinValues());
    }

    // Coin isimlerini baþlat
    void InitializeCoinNames()
    {
        coinNames = new string[10];  // Baþlangýçta 10 elemanlý bir dizi oluþturabilirsiniz

        coinNames[0] = "BTC";
        coinNames[1] = "ETH";
        coinNames[2] = "ADA";
        coinNames[3] = "XRP";
        coinNames[4] = "DOGE";
        coinNames[5] = "LTC";
        coinNames[6] = "BCH";
        coinNames[7] = "LINK";
        coinNames[8] = "DOT";
        coinNames[9] = "SOL";
    }

    // Coin deðerlerini baþlat
    void InitializeCoinValues()
    {
        coinValues = new float[10];  // Baþlangýçta 10 elemanlý bir dizi oluþturabilirsiniz

        for (int i = 0; i < coinNames.Length; i++)
        {
            coinValues[i] = Random.Range(1f, 100f);  // 1 ile 100 arasýnda rastgele deðerler
            Debug.Log("acýlýs: "+coinValues[i] + coinNames[i] + i);

        }
    }

    // Coin deðerlerini ekranda göster
    void DisplayCoinValues()
    {
        Debug.Log(coinNameTexts.Length);
        Debug.Log(coinNames.Length);

        for (int i = 0; i < coinNames.Length; i++)
        {
            Debug.Log(coinNames[i]);

            // Eðer coinNameTexts dizisinde yeterli öðe varsa, coin ismini güncelle
            if (i < coinNameTexts.Length)
            {
                coinNameTexts[i].SetText(coinNames[i]);
            }

            // Eðer coinValueTexts dizisinde yeterli öðe varsa, coin deðerini güncelle
            if (i < coinValueTexts.Length)
            {
                coinValueTexts[i].text = "$" + coinValues[i].ToString("F2");
            }

        }
    }

        // Coin deðerlerini her 30 saniyede bir güncelleyen Coroutine
    IEnumerator UpdateCoinValues()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);  // 30 saniye bekle

            for (int i = 0; i < coinNameTexts.Length; i++)
            {
                // %20'ye kadar deðiþim
                float changeAmount = coinValues[i] * Random.Range(-0.02f, 0.02f);
                coinValues[i] += changeAmount;

                // Coin deðerlerini güncelle ve ekrana yazdýr
                coinValueTexts[i].text = "$" + coinValues[i].ToString("F2");
            }
        }
    }
    public void SelectCoin(int index)
    {
        selectedCoinIndex = index;
        Debug.Log($"Seçilen Coin: {coinNames[selectedCoinIndex]} - Deðer: ${coinValues[selectedCoinIndex]:F2}");
    }

    public void BuyCoin()
    {
        int coinIndex = selectedCoinIndex;  // Sabit bir coin index deðeri
        float totalCost = coinValues[coinIndex] * 1;  // 1 coin almak
        if (balance >= totalCost)
        {
            balance -= totalCost;  // Coin alýrken bakiyeden düþüyoruz
            ownedCoins[coinIndex] += 1;  // Coin miktarýný artýrýyoruz

            balanceText.text = "$" + balance.ToString("F2");
            DisplayCoins();
            Debug.Log("deðer: "+coinValues[coinIndex]);

        }
        else
        {
            Debug.Log("Yetersiz bakiye!");
        }
    }


    public void SellCoin()
    {
        int coinIndex = selectedCoinIndex;  // Sabit bir coin index deðeri
        if (ownedCoins[coinIndex] > 0)  // Coin var mý?
        {
            float sellPrice = coinValues[coinIndex] * 0.9f;  // Satýþ fiyatý, coin'in deðerinin %90'ý olacak
            ownedCoins[coinIndex] -= 1;  // Coin miktarýný azaltýyoruz
            balance += sellPrice;  // Satýldýðýnda bakiyeyi artýrýyoruz

            balanceText.text = "$" + balance.ToString("F2");
            DisplayCoins();
        }
        else
        {
            Debug.Log("Satýlacak coin yok!");
        }
    }

    private void DisplayCoins()
    {
        // Coinlerin UI'ye yansýtýlmasýný saðlayan kod
        for (int i = 0; i < coinValueTexts.Length; i++)
        {
            // Coin adý ve deðerini UI Text'ine aktar
            coinValueTexts[i].text = $"{coinNames[i]}: ${coinValues[i]:F2}";
        }
    }


}
