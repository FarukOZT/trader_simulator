using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin
{
    public string name; // Coin ad� (�rne�in Bitcoin, Ethereum)
    public float price; // Coin fiyat�

    public Coin(string name, float price)
    {
        this.name = name;
        this.price = price;
    }
}

