using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuwelCount2 : MonoBehaviour
{
    bool JuwelDestroy = false;//��΂����������
    public GameObject Juwel;

    // Start is called before the first frame update
    void Start()
    {
        //���1����肵�Ă�����
        if (GameManager.Instance.Juwel3Get)
        {
            Destroy(Juwel);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // �u��΂����v������
        if (Input.GetKey(KeyCode.A) && !JuwelDestroy)
        {
            Destroy(Juwel);
            GameManager.Instance.JuwelCount++;
            Debug.Log(GameManager.Instance.JuwelCount);
            JuwelDestroy = true;
            GameManager.Instance.Juwel3Get = true;
        }
    }
}



//�������s�������Ă�������������܂܂ɂ���������bool��gameManager��getset����
//���̃X�N