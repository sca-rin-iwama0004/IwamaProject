using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private int juwelCount = 0;
    private bool juwel1Get = false;
    private bool juwel2Get = false;
    private bool juwel3Get = false;

    private bool rightKey = false;


    private void Awake()
    {
        if (instance == null)
        {
            //最初のGameManagerインスタンスを設定する
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //既にインスタンスが存在するため、重複したGameManagerを破壊
            Destroy(gameObject);
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

}
