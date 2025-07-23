using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private int coinCount = 0;
    public TextMeshProUGUI coinText;

    private void OnTriggerEnter(Collider other)
    {
        // Controlla se l'oggetto ha il tag "Coin"
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            coinText.text = "Coin Collected: " + coinCount.ToString();
            Debug.Log(coinCount);
            Destroy(other.gameObject);
        }
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

}
