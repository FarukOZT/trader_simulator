using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class CoinMarketManager : MonoBehaviour
{
    public TextMeshProUGUI balanceText;  // Balance text
    public TextMeshProUGUI[] coinValueTexts = null;  // Coin de�erlerini g�sterecek text'ler
    public TextMeshProUGUI[] coinNameTexts;  // Coin isimlerini g�sterecek text'ler (yeni ekledim)
    private float[] coinValues;  // 10 coin i�in de�erler
    private string[] coinNames;  // 10 coin i�in isimler
    public InputField quantityInputField;  // Kullan�c�n�n girece�i miktar

    private float balance = 100f;  // Ba�lang�� bakiyesi (�rnek)
    private int[] ownedCoins = new int[10];  // Kullan�c�n�n sahip oldu�u coin say�s�
    private int selectedCoinIndex = -1; // Hi�bir coin se�ilmediyse -1.

    void Start()
    {
        // Coin isimlerini ve de�erlerini ba�lat
        InitializeCoinNames();
        InitializeCoinValues();

        // Balance'� ekrana yazd�r
        balanceText.text = "$" + balance.ToString("F2");

        // Coin de�erlerini ekrana yazd�r
        DisplayCoinValues();
        int length = Mathf.Min(coinNames.Length, coinNameTexts.Length, coinValues.Length);
        // Coin de�erlerini her 30 saniyede bir g�ncelle
        StartCoroutine(UpdateCoinValues());
    }

    // Coin isimlerini ba�lat
    void InitializeCoinNames()
    {
        coinNames = new string[10];  // Ba�lang��ta 10 elemanl� bir dizi olu�turabilirsiniz

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

    // Coin de�erlerini ba�lat
    void InitializeCoinValues()
    {
        coinValues = new float[10];  // Ba�lang��ta 10 elemanl� bir dizi olu�turabilirsiniz

        for (int i = 0; i < coinNames.Length; i++)
        {
            coinValues[i] = Random.Range(1f, 100f);  // 1 ile 100 aras�nda rastgele de�erler
            Debug.Log("ac�l�s: "+coinValues[i] + coinNames[i] + i);

        }
    }

    // Coin de�erlerini ekranda g�ster
    void DisplayCoinValues()
    {
        Debug.Log(coinNameTexts.Length);
        Debug.Log(coinNames.Length);

        for (int i = 0; i < coinNames.Length; i++)
        {
            Debug.Log(coinNames[i]);

            // E�er coinNameTexts dizisinde yeterli ��e varsa, coin ismini g�ncelle
            if (i < coinNameTexts.Length)
            {
                coinNameTexts[i].SetText(coinNames[i]);
            }

            // E�er coinValueTexts dizisinde yeterli ��e varsa, coin de�erini g�ncelle
            if (i < coinValueTexts.Length)
            {
                coinValueTexts[i].text = "$" + coinValues[i].ToString("F2");
            }

        }
    }

        // Coin de�erlerini her 30 saniyede bir g�ncelleyen Coroutine
    IEnumerator UpdateCoinValues()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);  // 30 saniye bekle

            for (int i = 0; i < coinNameTexts.Length; i++)
            {
                // %20'ye kadar de�i�im
                float changeAmount = coinValues[i] * Random.Range(-0.02f, 0.02f);
                coinValues[i] += changeAmount;

                // Coin de�erlerini g�ncelle ve ekrana yazd�r
                coinValueTexts[i].text = "$" + coinValues[i].ToString("F2");
            }
        }
    }
    public void SelectCoin(int index)
    {
        selectedCoinIndex = index;
        Debug.Log($"Se�ilen Coin: {coinNames[selectedCoinIndex]} - De�er: ${coinValues[selectedCoinIndex]:F2}");
    }

    public void BuyCoin()
    {
        int coinIndex = selectedCoinIndex;  // Sabit bir coin index de�eri
        float totalCost = coinValues[coinIndex] * 1;  // 1 coin almak
        if (balance >= totalCost)
        {
            balance -= totalCost;  // Coin al�rken bakiyeden d���yoruz
            ownedCoins[coinIndex] += 1;  // Coin miktar�n� art�r�yoruz

            balanceText.text = "$" + balance.ToString("F2");
            DisplayCoins();
            Debug.Log("de�er: "+coinValues[coinIndex]);

        }
        else
        {
            Debug.Log("Yetersiz bakiye!");
        }
    }


    public void SellCoin()
    {
        int coinIndex = selectedCoinIndex;  // Sabit bir coin index de�eri
        if (ownedCoins[coinIndex] > 0)  // Coin var m�?
        {
            float sellPrice = coinValues[coinIndex] * 0.9f;  // Sat�� fiyat�, coin'in de�erinin %90'� olacak
            ownedCoins[coinIndex] -= 1;  // Coin miktar�n� azalt�yoruz
            balance += sellPrice;  // Sat�ld���nda bakiyeyi art�r�yoruz

            balanceText.text = "$" + balance.ToString("F2");
            DisplayCoins();
        }
        else
        {
            Debug.Log("Sat�lacak coin yok!");
        }
    }

    private void DisplayCoins()
    {
        // Coinlerin UI'ye yans�t�lmas�n� sa�layan kod
        for (int i = 0; i < coinValueTexts.Length; i++)
        {
            // Coin ad� ve de�erini UI Text'ine aktar
            coinValueTexts[i].text = $"{coinNames[i]}: ${coinValues[i]:F2}";
        }
    }


}
