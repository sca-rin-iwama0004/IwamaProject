using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{
    private float speed = 2f;
    private float maxAngle = 10f;

    float  startTime;
    Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
       // startTime = Time.time;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //�^�C�g����F�̕��������E�ɗh�炷
        transform.rotation = startRotation * Quaternion.Euler(0f,0f,Mathf.Sin((Time.time) * speed) * maxAngle);
    }
}
/*https:// teratail.com/questions/313783*/
//Mathf.Sin((Time.time - startTime)�Ƃ��Ă���̂͂��̃X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g��
//�Q�[�����J�n���Ă���r���Ő�������ăV�[���ɒǉ����ꂽ���Ȃǂɍŏ���Sin�̈�����0�ɂȂ�悤�ɂ��邽�߁B
//�r������V�[���ɒǉ�����Ă��h��n�߂̉�]�l��Quaternion.Euler(0f,0f,0f)�ɂȂ邱�Ƃ��Ӑ}�B
//Mathf.Sin((Time.time)���\

//Mathf.Sin((Time.time)�������I�ȉ^��������
//https:// qiita.com/Nekomasu/items/f526b9392fd16f2bd243