using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    bool Moveing = false;//�J�����������Ă��邩
    bool search = false;//�ڂ������ׂ�������Ă��邩
 
    public GameObject mainCamera;

    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
         
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
        search = true; 
    }

    public void searchButton()//�X�ɒ��ׂ���������Ƃ�
    {
        if (!Moveing && !search)
        {
            StartCoroutine("Rotate");
            Moveing = true;
        }
    }
}
