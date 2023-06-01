using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public enum Mode
    {
        Play, //ˆÚ“®’†
        Gimmick,//ƒMƒ~ƒbƒN
        Text,
    }
    public Mode PlayMode;


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
        PlayMode = Mode.Play;
        Debug.Log(PlayMode);
    }


    void Update()
    {
        
    }
}
