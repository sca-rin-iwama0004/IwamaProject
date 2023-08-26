using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCounter : MonoBehaviour
{

    [SerializeField] float timeMinutes;
    public float timeSeconds;
    [SerializeField] Text timeText;
    [SerializeField] GameObject text;
    private static bool created = false;

    GameManager GM;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (!created) {
            created = true;
            DontDestroyOnLoad(this);
        }else
            Destroy(this.gameObject);

        timeSeconds = timeMinutes * 60;
    }

    
    void Update()
    {
        if(GM.PlayMode == GameManager.Mode.Play) { 
            timeSeconds -= Time.deltaTime;
            text.SetActive(true);
        }else
            text.SetActive(false);

        var span = new TimeSpan(0, 0, (int)timeSeconds);
        timeText.text = span.ToString(@"mm\:ss");
        if(timeSeconds <= 0)
        {
            timeSeconds = 0;
            SceneManager.LoadScene("gameoverScene");
            Debug.Log("TimeUp");
        }
        if (SceneManager.GetActiveScene().name == "gameclearScene") {
            GM.PlayMode = GameManager.Mode.end;
            
        }
    }
}
