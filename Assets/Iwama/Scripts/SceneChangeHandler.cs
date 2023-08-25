using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeHandler : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "gameoverScene" || scene.name == "gameclearScene" || scene.name == "HappyEndScene")
        {
            GameManager.instance.ResetFlags();
           // Debug.Log("ÉNÉäÉAà»äO");
        }

        if (scene.name == "rouyaScene")
        {
            GameManager.instance.ResultResetFlags();
            // Debug.Log("ÇQèTñ⁄");
            Debug.Log(GameManager.Instance.JuwelCount);
        }
    }
}