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
            //�ŏ���GameManager�C���X�^���X��ݒ肷��
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //���ɃC���X�^���X�����݂��邽�߁A�d������GameManager��j��
            Destroy(gameObject);
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

}
