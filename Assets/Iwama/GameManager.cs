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
    private bool juwel2Get = false;
    private bool juwel3Get = false;

    private bool rightKey = false;

    private bool stickGet = false;
    private bool meatGet = false;
    private bool greathellKey = false;//大広間の鍵

    private bool kanariaRescue = false;

    private static bool GameStart = false;
    public bool GameStartText = false;



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

    void Start()
    {
        PlayMode = Mode.Play;
        Debug.Log(PlayMode);
    }


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "rouyaScene" && !GameStart)
        {
            PlayMode = GameManager.Mode.Text;

            GameStart = true;
            GameStartText = true;
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

    public bool Juwel2Get
    {
        get { return juwel2Get; }
        set { juwel2Get = value; }
    }

    public bool Juwel3Get
    {
        get { return juwel3Get; }
        set { juwel3Get = value; }
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

    public bool MeatGet
    {
        get { return meatGet; }
        set { meatGet = value; }
    }

    public bool GreathellKey
    {
        get { return greathellKey; }
        set { greathellKey = value; }
    }

    public bool KanariaRescue
    {
        get { return kanariaRescue; }
        set { kanariaRescue = value; }
    }

    /*
     * KanariaスクリプトのKanariaRescue = trueの変更
     *   GameManager.Instance.KanariaRescue = true;
     * 
     */
}