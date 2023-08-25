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
           // Debug.Log("クリア以外");
        }

        if (scene.name == "rouyaScene")
        {
            GameManager.instance.ResultResetFlags();
            // Debug.Log("２週目");
            Debug.Log(GameManager.Instance.JuwelCount);
        }
    }
}