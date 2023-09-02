using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagReset : MonoBehaviour
{
    SafeGimmick safe;
    SafeKey safekey;
    ExitKey exitkey;
    ExitDoor exitdoor;
    BookShelf bookshelf;
    PasswordPanel1 pas;
    TimerCounter timer;

    public bool reset = false;
    void Start()
    {
        //safe = GameObject.Find("Safe").GetComponent<SafeGimmick>();
        //safekey = GameObject.Find("SafeKey").GetComponent<SafeKey>();
        //exitkey = GameObject.Find("ExitKey").GetComponent<ExitKey>();
        //exitdoor = GameObject.Find("ExitDoor").GetComponent<ExitDoor>();
        //bookshelf = GameObject.Find("bookcase").GetComponent<BookShelf>();
        //pas = GameObject.Find("ImagePanel").GetComponent<PasswordPanel1>();
        //timer = GameObject.Find("Timer").GetComponent<TimerCounter>();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "gameclearScene" || 
            SceneManager.GetActiveScene().name == "gameoverScene" || 
            SceneManager.GetActiveScene().name == "HappyEndScene")
        {
            //Debug.Log("reset");
            //reset = true;
            //SafeGimmick.open = false;
            //SafeKey.safeKey = false;
            //SafeKey.safeKeyUsed = false;
            //ExitKey.exitKey = false;
            //ExitKey.exitKeyUsed = false;
            //ExitDoor.open = false;
            //BookShelf.gimmick = false;
            PasswordPanel1.ans = false;
            //GameManager.GameStart = false;

            //TimerCounter.timeSeconds = 300;
        }

    }
}
