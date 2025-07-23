using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    [SerializeField] private float fallYThreshold = -10f;

    [Header("UI Lose Panel")]
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TextMeshProUGUI coinCollectedText;

    [Header("Player Reference")]
    [SerializeField] private GameObject playerObject; // stesso oggetto con movimento e coin

    [SerializeField] private HealthBarUI healthBarUI;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBarUI != null)
        {
            healthBarUI.SetHealth(currentHealth, maxHealth);
        }
    }

    void Update()
    {
        if (!isDead && transform.position.y < fallYThreshold)
        {
            Die();
        }
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        if (healthBarUI != null)
        {
            healthBarUI.SetHealth(currentHealth, maxHealth);
        }

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        currentHealth = 0f;

        if (losePanel != null)
        {
            losePanel.SetActive(true);

            if (playerObject.TryGetComponent(out CoinCollection coinScript))
            {
                int coins = coinScript.GetCoinCount();
                if (coinCollectedText != null)
                    coinCollectedText.text = "Monete: " + coins;
            }
        }

        if (playerObject.TryGetComponent(out ThirdPersonMovement pc))
        {
            pc.enabled = false;
        }
    }
}
