using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ArchTrigger : MonoBehaviour
{
    [SerializeField] private CoinCollection playerCoinCollection;
    [SerializeField] private int coinsNeeded = 5;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private TextMeshProUGUI coinCollectedText;

    private bool levelCompleted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (levelCompleted) return;

        if (other.CompareTag("Player"))
        {
            CheckVictory(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (levelCompleted) return;

        if (other.CompareTag("Player"))
        {
            CheckVictory(other);
        }
    }

    private void CheckVictory(Collider playerCollider)
    {
        int collected = playerCoinCollection.GetCoinCount();
        if (collected > coinsNeeded)
        {
            levelCompleted = true;

            winPanel.SetActive(true);
            coinCollectedText.text = "Monete: " + collected;

            if (playerCollider.TryGetComponent(out ThirdPersonMovement pc))
            {
                pc.enabled = false;
            }
            else
            {
                Debug.LogWarning("ThirdPersonMovement non trovato sul player!");
            }

            Time.timeScale = 0f; // blocca il gioco
            Debug.Log("Livello completato!");
        }
        else
        {
            Debug.Log("Non hai abbastanza coin!");
        }
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // riattiva il gioco
        SceneManager.LoadScene("Menu");
    }
}
