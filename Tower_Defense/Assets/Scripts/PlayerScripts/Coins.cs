using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public int coinsAmmount = 0;

    public TMP_Text coinsText;
    public void UpdateCoins(int coinsToAdd)
    {
        coinsAmmount += coinsToAdd;
        coinsText.text = "Coins: " + coinsAmmount.ToString();
    }
}
