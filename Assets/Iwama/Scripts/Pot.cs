using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    bool Moveing = false;//�J�����������Ă��邩
 //   bool nozoku = false;//A�{�^�������ꂽ��
 
    public GameObject mainCamera;
    bool A_Destroy = false;

    void Start()
    {
  
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
                //if (!Moveing && !nozoku)
                if (!Moveing )
                    StartCoroutine("Rotate");
                     Moveing = true;
            }

            /*
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
           
            */
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
      //  nozoku = true;
        
    }
 }

//Rotate��mainCamera�̂Ƃ��͍쓮���Ȃ��悤�ɂ������B