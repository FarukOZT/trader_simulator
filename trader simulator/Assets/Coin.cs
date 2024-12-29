using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin
{
    public string name; // Coin adý (örneðin Bitcoin, Ethereum)
    public float price; // Coin fiyatý

    public Coin(string name, float price)
    {
        this.name = name;
        this.price = price;
    }
}

