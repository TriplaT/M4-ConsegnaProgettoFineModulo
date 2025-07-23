using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    public void setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Monete: " + score.ToString();
    }
}
