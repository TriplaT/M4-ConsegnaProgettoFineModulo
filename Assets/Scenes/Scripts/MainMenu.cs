using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Gameplay";
    [Header("UI Elements")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    private bool isLoading = false;

    private void Awake()
    {
        // Assicuriamoci che i bottoni siano abilitati all'avvio
        SetButtonsInteractable(true);
    }

    public void PlayGame()
    {
        if (isLoading) return;

        StartCoroutine(LoadGameSceneAsync());
    }

    private IEnumerator LoadGameSceneAsync()
    {
        isLoading = true;
        SetButtonsInteractable(false);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gameSceneName);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    public void QuitGame()
    {
        if (isLoading) return;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    private void SetButtonsInteractable(bool state)
    {
        if (playButton != null) playButton.interactable = state;
        if (exitButton != null) exitButton.interactable = state;
    }
}
