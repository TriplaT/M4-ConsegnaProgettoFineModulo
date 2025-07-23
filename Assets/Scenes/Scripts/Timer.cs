using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime = 60f;

    [Header("Lose Panel Stuff")]
    [SerializeField] private int coinsNeeded = 5;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TextMeshProUGUI coinCollectedText;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button exitButton;

    [Header("Player")]
    [SerializeField] private GameObject playerObject; 

    private bool hasEnded = false;

    void Start()
    {
        retryButton.onClick.AddListener(RetryLevel);
        exitButton.onClick.AddListener(ExitToMenu);
    }

    void Update()
    {
        if (hasEnded) return;

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(remainingTime / 60F);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
        else
        {
            remainingTime = 0;
            EndLevelCheck();
        }
    }

    private void EndLevelCheck()
    {
        hasEnded = true;

        CoinCollection coinScript = playerObject.GetComponent<CoinCollection>();
        int coinsCollected = coinScript != null ? coinScript.GetCoinCount() : 0;

        if (coinsCollected <= coinsNeeded)
        {
            Debug.Log("Tempo scaduto! Non abbastanza coin. Game Over.");

            losePanel.SetActive(true);
            if (coinCollectedText != null)
                coinCollectedText.text = "Monete: " + coinsCollected;

            if (playerObject.TryGetComponent(out ThirdPersonMovement pc))
            {
                pc.enabled = false;
            }
        }
    }

    private void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
