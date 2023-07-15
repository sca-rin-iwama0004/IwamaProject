using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatueMove : MonoBehaviour
{
    public Transform MoveObj;
    public Transform target;//�����̑ΏۂƂȂ�I�u�W�F�N�g
    public float maxDistance = 100f;//���_�𔻒肷��ő勗��
    public bool isLookingAtTarget = false;//�������m�̖ڂ������Ă��邩

    bool Moveing = false;
    public AudioClip sound;
    AudioSource audioSource;

    Ray ray;

    //Unity�ŃI�u�W�F�N�g�����߂��������ǂ��������o������
    //�����_�̕����⋗���𔻒肷��K�v������
    void Start()
    {
        //�E�̃h�A�̂������J���Ă�����
       if (GameManager.Instance.RightKey)
       {
            MoveObj.transform.Rotate(0,-90,0);
       }

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //�����𓮂���
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            int mask = 1 << 6;//MoveButton�ɂ���ray��������Ȃ��悤��

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                if (!isLookingAtTarget && !GameManager.Instance.RightKey)
                {
                    if (!Moveing)
                         StartCoroutine("Rotate");
                        Moveing = true;
                }
            }
        }

        DirectionCheck();

        UnlockCheck();
    }

    IEnumerator Rotate()
    {
        audioSource.PlayOneShot(sound);

        for (int turn = 0; turn < 90; turn++)
        {
            MoveObj.transform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.01f);
        }
        Moveing = false;
    }

    public void DirectionCheck()//���������������Ă��邩�̔���
    {
        //�����̈ʒu����^�[�Q�b�g�܂ł̃x�N�g�������߂�
        Vector3 direction = target.position - MoveObj.transform.position;

        //�^�[�Q�b�g�܂ł̋������ő勗���ȓ��ł���Ύ��_�𔻒肷��
        if (direction.magnitude <= maxDistance)
        {
            //�����̐��ʕ����ƃ^�[�Q�b�g�ւ̕����̓��ς��v�Z
            float dot = Vector3.Dot(MoveObj.transform.forward, direction.normalized);

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
    }

    public void UnlockCheck() //���������������Ă����献������
    {
        if (isLookingAtTarget)
        {
            GameManager.Instance.RightKey = true;
        }
        else
        {
            GameManager.Instance.RightKey = false;
        }
    }
}