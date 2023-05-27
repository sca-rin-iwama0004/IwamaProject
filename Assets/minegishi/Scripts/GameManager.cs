using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public enum Mode
    {
        Play, //移動中
        Gimmick,//ギミック
        Text,
    }

    public Mode playMode;

     void ModeChange()
    {

    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        playMode = Mode.Play;
        Debug.Log(playMode);
    }


    void Update()
    {
        
    }
}
