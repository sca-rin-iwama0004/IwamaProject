using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public enum Mode
    {
        Play, //�ړ���
        Gimmick,//�M�~�b�N
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
    private bool stickUsed = false;
    private bool meatGet = false;
    private bool meatUsed = false;
    private bool greathellKey = false;//��L�Ԃ̌�

    private bool kanariaRescue = false;

    public static bool GameStart = false;
    public bool GameStartText = false;
    public static bool robotEncounter = false;
    public bool robotText = false;

    private bool happyEnd = false;
    private bool gameClear = false;

    private void Awake()
    {
        if (instance == null)
        {
            //�ŏ���GameManager�C���X�^���X��ݒ肷��
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���ɃC���X�^���X�����݂��邽�߁A�d������GameManager��j��
            Destroy(this.gameObject);
        }
    }

    public void ResetFlags()
    {
        juwelCount = 0;
        juwel1Get = false;
        juwel2Get = false;
        juwel3Get = false;

        rightKey = false;

        stickGet = false;
        stickUsed = false;
        meatGet = false;
        meatUsed = false;
        greathellKey = false;//��L�Ԃ̌�

        kanariaRescue = false;

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
        if (SceneManager.GetActiveScene().name == "rouyaScene" && !GameStart) //�Q�[���J�n���̃e�L�X�g
        {
            PlayMode = GameManager.Mode.Text;

            GameStart = true;
            GameStartText = true;
            TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
            StartCoroutine(text.Cotest());
        }

        //PasswordPanel1 pas = GameObject.Find("ImagePanel").GetComponent<PasswordPanel1>();
        if (SceneManager.GetActiveScene().name == "VaultRoom" && PasswordPanel1.ans == false && !robotEncounter) //�p�X���[�h����͂����ɕ����ɓ���ƃe�L�X�g�\��
        {
            PlayMode = GameManager.Mode.Text;

            robotEncounter = true;
            robotText = true;
            TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
            StartCoroutine(text.Cotest());
        }

    }
    // GameManager�̃C���X�^���X���擾����v���p�e�B
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

    public bool StickUsed {
        get { return stickUsed;}
        set { stickUsed = value;}
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