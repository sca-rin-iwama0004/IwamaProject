using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot2 : MonoBehaviour
{
   bool Moveing = false;//�J�����������Ă��邩
    bool nozoku = false;//�`���{�^�������ꂽ��
    public GameObject mainCamera;

    bool JuwelDestroy = false;//��΂����������

    public GameObject Juwel;
   
    // Update is called once per frame
    void Update()
    {
        //���C���J��������A�N�e�B�u��Ԃ������Ƃ�
        //�����J�������A�b�v�ɂȂ��ăA�C�e�����񂶂�Ȃ����H
        //�����`�F�b�N�{�^���őΉ����Ă����Ǝv��
        if (mainCamera.activeSelf == false)
        {
            //mainCamera��false�̎��͋߂��Ō����������Ă���Ƃ�
            //�S���A�E�����Łu����`���v�n����I�������Ƃ�
            if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.B) && !JuwelDestroy && nozoku)
                {
                    JuwelGet();
                }
                // ������StartCoroutine("Rotate")�݂����Ȃ̂�����񂶂�H;
            }

            //��L�ԂŁu����`���v��I�������Ƃ�
            if (Input.GetKey(KeyCode.C))
            {
                if((!Moveing && !nozoku))
                StartCoroutine("Rotate");
                Moveing = true;
            }
            if (Input.GetKey(KeyCode.A) && !JuwelDestroy && nozoku)
            {
                JuwelGet();
            }
            //��������J�E���g1�񂾂�����
            //bool���ĂȂ����Ⴂ���Ȃ�false
        }
    }


    public void JuwelGet()
    {
        // �u��΂����v���������Ƃ�
        //if (Input.GetKey(KeyCode.A) && !JuwelDestroy)
       // {
            //this.gameObject���Ƃ��Ƃ��߂�
            // Destroy(this.gameObject);
            Destroy(this.gameObject);
        GameManager.Instance.JuwelCount++;
            Debug.Log(GameManager.Instance.JuwelCount);
            JuwelDestroy = true;
       // }
    }

    IEnumerator Rotate()//�J�������X����
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
