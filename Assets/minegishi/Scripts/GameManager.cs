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
    private bool meatGet = false;
    private bool greathellKey = false;//��L�Ԃ̌�

    private bool kanariaRescue = false;

    private static bool GameStart = false;
    public bool GameStartText = false;



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
     * Kanaria�X�N���v�g��KanariaRescue = true�̕ύX
     *   GameManager.Instance.KanariaRescue = true;
     * 
     */
}