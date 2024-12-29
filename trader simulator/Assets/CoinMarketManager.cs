using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class CoinMarketManager : MonoBehaviour
{
    public TextMeshProUGUI balanceText;  // Balance text
    public TextMeshProUGUI[] coinValueTexts;  // Coin de�erlerini g�sterecek text'ler
    public TextMeshProUGUI[] coinNameTexts;  // Coin isimlerini g�sterecek text'ler (yeni ekledim)
    private float[] coinValues = new float[10];  // 10 coin i�in de�erler
    private string[] coinNames = new string[10];  // 10 coin i�in isimler
    public InputField quantityInputField;  // Kullan�c�n�n girece�i miktar

    private float balance = 100f;  // Ba�lang�� bakiyesi (�rnek)
    private int[] ownedCoins = new int[10];  // Kullan�c�n�n sahip oldu�u coin say�s�

    void Start()
    {
        // Coin isimlerini ve de�erlerini ba�lat
        InitializeCoinNames();
        InitializeCoinValues();

        // Balance'� ekrana yazd�r
        balanceText.text = "$" + balance.ToString("F2");

        // Coin de�erlerini ekrana yazd�r
        DisplayCoinValues();

        // Coin de�erlerini her 30 saniyede bir g�ncelle
        StartCoroutine(UpdateCoinValues());
    }

    // Coin isimlerini ba�lat
    void InitializeCoinNames()
    {
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
        for (int i = 0; i < 1; i++)
        {
            coinValues[i] = Random.Range(1f, 100f);  // 1 ile 100 aras�nda rastgele de�erler
        }
    }

    // Coin de�erlerini ekranda g�ster
    void DisplayCoinValues()
    {
        for (int i = 0; i < 1; i++)
        {
            // Coin ismini ve de�erini ekrana yazd�r
            coinNameTexts[i].text = coinNames[i];  // Coin ismini yazd�r
            coinValueTexts[i].text = "$" + coinValues[i].ToString("F2");  // Coin de�erini yazd�r
        }
    }

    // Coin de�erlerini her 30 saniyede bir g�ncelleyen Coroutine
    IEnumerator UpdateCoinValues()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);  // 30 saniye bekle

            for (int i = 0; i < 1; i++)
            {
                // %20'ye kadar de�i�im
                float changeAmount = coinValues[i] * Random.Range(-0.2f, 0.2f);
                coinValues[i] += changeAmount;

                // Coin de�erlerini g�ncelle ve ekrana yazd�r
                coinValueTexts[i].text = "$" + coinValues[i].ToString("F2");
            }
        }
    }

    public void BuyCoin()
    {
        int coinIndex = 0;  // Sabit bir coin index de�eri
        float totalCost = coinValues[coinIndex] * 1;  // 1 coin almak
        if (balance >= totalCost)
        {
            balance -= totalCost;  // Coin al�rken bakiyeden d���yoruz
            ownedCoins[coinIndex] += 1;  // Coin miktar�n� art�r�yoruz

            balanceText.text = "$" + balance.ToString("F2");
            DisplayCoins();
        }
        else
        {
            Debug.Log("Yetersiz bakiye!");
        }
    }


    public void SellCoin()
    {
        int coinIndex = 0;  // Sabit bir coin index de�eri
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
