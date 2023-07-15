using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //
        if (Input.GetKey(KeyCode.UpArrow) && SceneManager.GetActiveScene().name == "rouyaScene")
        {
            SceneManager.LoadScene("SampleScene");
        }

        if(Input.GetKey(KeyCode.DownArrow) && SceneManager.GetActiveScene().name == "SampleScene")
        {
            SceneManager.LoadScene("rouyaScene");
        }

        if (Input.GetKey(KeyCode.LeftArrow) && SceneManager.GetActiveScene().name == "RightroomScene")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
        // SceneManager.LoadScene("rouyaScene");
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("rouyaScene");
    }

    public void EndButton()
    {
        SceneManager.LoadScene("titleScene");
    }

}
