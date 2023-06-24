using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatueMove : MonoBehaviour
{
    public Transform target;//�����̑ΏۂƂȂ�I�u�W�F�N�g
    public float maxDistance = 10f;//���_�𔻒肷��ő勗��
    public bool isLookingAtTarget = false;//�t���O

    bool Moveing = false;
    public AudioClip sound;
    AudioSource audioSource;

     //bool rightDoor = false;//���̃t���O�͂���Ȃ������H
    //private�������Ă������Ȃ��Ă������̂�

    //Unity�ŃI�u�W�F�N�g�����߂��������ǂ��������o������
    //�����_�̕����⋗���𔻒肷��K�v������

    void Start()
    {
        //�E�̃h�A�̂������J���Ă�����
       if (GameManager.Instance.RightKey)
       {
            this.transform.Rotate(0,-90,0);
       }

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //�����𓮂���
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isLookingAtTarget && !GameManager.Instance.RightKey)
            {
               if (!Moveing)
               StartCoroutine("Rotate");
               Moveing = true;
            } 
        }

        //�����̈ʒu����^�[�Q�b�g�܂ł̃x�N�g�������߂�
        Vector3 direction = target.position - transform.position;

        //�^�[�Q�b�g�܂ł̋������ő勗���ȓ��ł���Ύ��_�𔻒肷��
        if (direction.magnitude <= maxDistance)
        {
            //�����̐��ʕ����ƃ^�[�Q�b�g�ւ̕����̓��ς��v�Z
            float dot = Vector3.Dot(transform.forward, direction.normalized);

            //���ς��P�ɋ߂��قǎ����������Ă���Ɣ��f����
            if (dot >= 0.9f)
            {
                isLookingAtTarget = true;
            }
            else
            {
                isLookingAtTarget = false;
            }
        }
        else
        {
            isLookingAtTarget = false;
        }

        if (Input.GetKey(KeyCode.Return))
        {
            //�h�A�̓h�A���J������������V�[�����ς��悤��
            if (isLookingAtTarget)
            {
                SceneManager.LoadScene("RightroomScene");
            }
        }
    }

    IEnumerator Rotate()
    {
        audioSource.PlayOneShot(sound);

        for (int turn = 0; turn < 90; turn++)
        {
            transform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.01f);
        }
        Moveing = false;


        //�ڂƖڂ������Ă��邩���肷��
        if (isLookingAtTarget)
        {
           // Debug.Log("�ڂ������Ă���");
            GameManager.Instance.RightKey = true;
           // Debug.Log(rightDoor);
          
        }
        else
        {
            //Debug.Log("�ڂ������ĂȂ�");
            GameManager.Instance.RightKey = false;
            //  Debug.Log(rightDoor);
        }
    }

}



