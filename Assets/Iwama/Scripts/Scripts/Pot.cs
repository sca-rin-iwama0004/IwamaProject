using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    bool Moveing = false;//�J�����������Ă��邩
    bool nozoku = false;//A�{�^�������ꂽ��
 
    public GameObject Juwel;

    public GameObject mainCamera;
    bool A_Destroy = false;

    void Start()
    {
        //���1����肵�Ă�����
        if (GameManager.Instance.Juwel2Get)
        {
            Destroy(Juwel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //���C���J��������A�N�e�B�u��Ԃ������Ƃ�
        if (mainCamera.activeSelf == false)
        {
            //�I����(�����̂���)���\�����ꂽ�Ƃ�
            if (Input.GetKey(KeyCode.C))
            {
                if (!Moveing && !nozoku)
                    StartCoroutine("Rotate");
                     Moveing = true;
            }

            if (nozoku)//��΂������������Ƃ�
            {
                if (Input.GetKey(KeyCode.D) && !A_Destroy)
                {
                    GameManager.Instance.JuwelCount++;
                    Destroy(Juwel);
                    Debug.Log(GameManager.Instance.JuwelCount);
                    A_Destroy = true;
                    GameManager.Instance.Juwel2Get = true;
                }
            }
            //��������J�E���g1�񂾂�����
            //bool���ĂȂ����Ⴂ���Ȃ�false
        }
        
    }

    IEnumerator Rotate()
    {
        for (int turn = 0; turn < 70; turn++)
        {
            transform.Rotate(1, 0, 0);
            yield return new WaitForSeconds(0.02f);
            //��x����̏����A����
        }
        Moveing = false;
        nozoku = true;
        
    }
 }

//Rotate��mainCamera�̂Ƃ��͍쓮���Ȃ��悤�ɂ������B