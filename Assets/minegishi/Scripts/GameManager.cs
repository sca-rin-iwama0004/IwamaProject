using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public enum Mode
    {
        Play, //移動中
        Gimmick,//ギミック
        Text,
        end,
    }
    public Mode PlayMode;

    private int juwelCount = 0;
    private bool juwel1Get = false;
    private bool juwel1Used = false;
    private bool juwel1Text = false;
    private bool juwel2Get = false;
    private bool juwel2Used = false;
    private bool juwel2Text = false;
    private bool juwel3Get = false;
    private bool juwel3Used = false;
    private bool juwel3Text = false;

    private bool rightKey = false;

    private bool stickGet = false;
    private bool stickUsed = false;
    private bool stickText = false;
    private bool meatGet = false;
    private bool meatUsed = false;
    private bool meatText = false;
    private bool rouyaKeyGet = false;//牢屋の鍵
    private bool rouyaKeyUsed = false;
    private bool rouyaKeyText = false;

    private bool manualText = false;

    private bool kanariaRescue = false;
    private bool kanariaText = false;

    public static bool GameStart = false;
    public bool GameStartText = false;
    public static bool robotEncounter = false;
    public bool robotText = false;

    private bool safeKeyGet = false;
    private bool safeKeyUsed = false;
    private bool safeKeyText = false;

    private bool safeOpen = false;
    private bool safeText = false;

    private bool bookshelfGimmick = false;
    private bool bookshelfText = false;

    private bool exitKeyGet = false;
    private bool exitKeyUsed = false;
    private bool exitKeyText = false;
    private bool exitDoorOpen = false;
    private bool exitDoorText = false;

    private bool happyEnd = false;
    private bool gameClear = false;

    private void Awake()
    {
        if (instance == null)
        {
            //最初のGameManagerインスタンスを設定する
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //既にインスタンスが存在するため、重複したGameManagerを破壊
            Destroy(this.gameObject);
        }
    }

    public void ResetFlags()
    {
        juwelCount = 0;
        juwel1Get = false;
        juwel1Used = false;
        juwel2Get = false;
        juwel2Used = false;
        juwel3Get = false;
        juwel3Used = false;

        rightKey = false;

        stickGet = false;
        stickUsed = false;
        meatGet = false;
        meatUsed = false;
        rouyaKeyGet = false;//大広間の鍵
        rouyaKeyUsed = false;

        kanariaRescue = false;
        safeKeyGet = false;
        safeKeyUsed = false;
        safeOpen = false;
        bookshelfGimmick = false;

        exitDoorOpen = false;

        GameStart = false;
        GameStartText = false;

        robotEncounter = false;

    }

    public void ResultResetFlags()
    {
        happyEnd = false;
        gameClear = false;
    }

    void Start()
    {
        PlayMode = Mode.Play;
        Debug.Log(PlayMode);
    }


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "rouyaScene" && !GameStart) //ゲーム開始時のテキスト
        {
            PlayMode = GameManager.Mode.Text;

            GameStart = true;
            GameStartText = true;
            TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
            StartCoroutine(text.Cotest());
        }

        //PasswordPanel1 pas = GameObject.Find("ImagePanel").GetComponent<PasswordPanel1>();
        if (SceneManager.GetActiveScene().name == "VaultRoom" && PasswordPanel1.ans == false && !robotEncounter) //パスワードを入力せずに部屋に入るとテキスト表示
        {
            PlayMode = GameManager.Mode.Text;

            robotEncounter = true;
            robotText = true;
            TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
            StartCoroutine(text.Cotest());
        }

    }
    // GameManagerのインスタンスを取得するプロパティ
    public static GameManager Instance
    {
        get { return instance; }
    }

    public int JuwelCount
    {
        get { return juwelCount; }
        set { juwelCount = value; }
    }

    public bool Juwel1Get
    {
        get { return juwel1Get; }
        set { juwel1Get = value; }
    }

    public bool Juwel1Used
    {
        get { return juwel1Used;}
        set { juwel1Used = value;}
    }
    public bool Juwel1Text
    {
        get { return juwel1Text;}
        set { juwel1Text = value;}
    }

    public bool Juwel2Get
    {
        get { return juwel2Get; }
        set { juwel2Get = value; }
    }

    public bool Juwel2Used
    {
        get { return juwel2Used;}
        set { juwel2Used = value;}
    }
    public bool Juwel2Text
    {
        get { return juwel2Text;}
        set { juwel2Text = value;}
    }

    public bool Juwel3Get
    {
        get { return juwel3Get; }
        set { juwel3Get = value; }
    }

    public bool Juwel3Used
    {
        get { return juwel3Used;}
        set { juwel3Used = value;}
    }
    public bool Juwel3Text
    {
        get { return juwel3Text;}
        set { juwel3Text = value;}
    }

    public bool RightKey
    {
        get { return rightKey; }
        set { rightKey = value; }
    }

    public bool StickGet
    {
        get { return stickGet; }
        set { stickGet = value; }
    }
    public bool StickUsed {
        get { return stickUsed;}
        set { stickUsed = value;}
    }
    public bool StickText
    {
        get { return stickText;}
        set { stickText = value;}
    }

    public bool MeatGet
    {
        get { return meatGet; }
        set { meatGet = value; }
    }
    public bool MeatUsed {
        get { return meatUsed;}
        set { meatUsed = value;}
    }
    public bool MeatText
    {
        get { return meatText;}
        set { meatText = value;}
    }

    public bool RouyaKeyGet
    {
        get { return rouyaKeyGet; }
        set { rouyaKeyGet = value; }
    }
    public bool RouyaKeyUsed
    {
        get { return rouyaKeyUsed;}
        set { rouyaKeyUsed = value;}
    }
    public bool RouyaKeyText
    {
        get { return rouyaKeyText;}
        set { rouyaKeyText = value;}
    }

    public bool SafeKeyGet
    {
        get { return safeKeyGet;}
        set { safeKeyGet = value;}
    }
    public bool SafeKeyUsed
    {
        get { return safeKeyUsed;}
        set { safeKeyUsed = value;}
    }
    public bool SafeKeyText
    {
        get { return safeKeyText;}
        set { safeKeyText = value;}
    }

    public bool SafeOpen
    {
        get { return safeOpen;}
        set { safeOpen = value;}
    }
    public bool SafeText
    {
        get { return safeText;}
        set { safeText = value;}
    }

    public bool BookShelfGimmick
    {
        get { return bookshelfGimmick;}
        set { bookshelfGimmick = value;}
    }
    public bool BookShelfText
    {
        get { return bookshelfText;}
        set { bookshelfText = value;}
    }

    public bool ExitKeyGet
    {
        get { return exitKeyGet; }
        set { exitKeyGet = value; }
    }
    public bool ExitKeyUsed
    {
        get { return exitKeyUsed; }
        set { exitKeyUsed = value; }
    }

    public bool ExitKeyText
    {
        get { return exitKeyText; }
        set { exitKeyText = value; }
    }

    public bool ExitDoorOpen
    {
        get { return exitDoorOpen; }
        set { exitDoorOpen = value; }
    }

    public bool ExitDoorText
    {
        get { return exitDoorText;}
        set { exitDoorText = value;}
    }

    public bool ManualText
    {
        get { return manualText; }
        set { manualText = value;}
    }

    public bool KanariaRescue
    {
        get { return kanariaRescue; }
        set { kanariaRescue = value; }
    }
    public bool KanariaText
    {
        get { return kanariaText;}
        set { kanariaText = value;}
    }

    public bool HappyEnd
    {
        get { return happyEnd; }
        set { happyEnd = value; }
    }

    public bool GameClear
    {
        get { return gameClear; }
        set { gameClear = value; }
    }
}