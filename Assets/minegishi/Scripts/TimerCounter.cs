using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCounter : MonoBehaviour
{
    [SerializeField] float timeMinutes;
    [SerializeField]float timeSeconds;
    [SerializeField] Text timeText;
    private static bool created = false;

    void Start()
    {
        if (!created) {
            created = true;
            DontDestroyOnLoad(this);
        }else
            Destroy(this.gameObject);

        timeSeconds = timeMinutes * 60;
    }

    
    void Update()
    {
        timeSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)timeSeconds);
        timeText.text = span.ToString(@"mm\:ss");
        if(timeSeconds <= 0)
        {
            timeSeconds = 0;
            Debug.Log("TimeUp");
        }
    }
}
