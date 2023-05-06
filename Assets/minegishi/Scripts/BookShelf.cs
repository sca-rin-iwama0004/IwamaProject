using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    private float startTime, distance;
    private Vector3 startPosition, targetPosition;

    enum STATE
    {
        WALK = 0,
        TEXT,
        GIMMICK,
    }

    void Start()
    {
        //�X�^�[�g���Ԃ��L���b�V��
        startTime = Time.time;
        //�X�^�[�g�ʒu���L���b�V��
        startPosition = transform.position;
        //�����n�_���Z�b�g
        targetPosition = new Vector3(0, 0, 10);
        //�ړI�n�܂ł̋��������߂�
        distance = Vector3.Distance(startPosition, targetPosition);

    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("�N���b�N");
            //���݃t���[���̕�Ԓl���v�Z
            float interpolatedValue = (Time.time - startTime) / distance;
            //�ړ�������
            transform.position = Vector3.Lerp(startPosition, targetPosition, interpolatedValue);
        }
    }
}
