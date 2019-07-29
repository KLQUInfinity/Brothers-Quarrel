using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider loadingSlider;      

    /// <summary>
    /// Exit the game
    /// </summary>
    public void QuitTheGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Load the MainMenu Scene
    /// </summary>
    public void BackToMainMenu()
    {
        StartCoroutine(LoadAsynchronously("MainMenu"));
    }

    /// <summary>
    /// Restart the current Scene
    /// </summary>
    public void RestartLevel()
    {
        StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().name));
    }

    /// <summary>
    /// Moving from scene to another
    /// </summary>
    /// <param name="sceneName">index of the scene you will go to</param>
    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    private IEnumerator LoadAsynchronously(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        if (loadingSlider)
        {
            while (!operation.isDone)
            {
                loadingSlider.value = operation.progress;

                yield return null;
            }
        }
        else
        {
            Debug.LogError("No loading Slider Found");
        }
    }
}
