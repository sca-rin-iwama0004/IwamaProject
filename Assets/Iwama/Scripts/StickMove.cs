using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StickMove : MonoBehaviour
{


    private bool isDragging = false; // �I�u�W�F�N�g���h���b�O�����ǂ����̃t���O
    private Vector3 offset; // �}�E�X�N���b�N�ʒu�ƃI�u�W�F�N�g�ʒu�̃I�t�Z�b�g
    //[SerializeField] GameObject key;
    [SerializeField] GameObject Portao;
    [SerializeField] GameObject collision;//�����蔻��̔�
    [SerializeField] GameObject stick;

    public Camera specificCamera;

    void OnMouseDown()
    {
        // �}�E�X�{�^���������ꂽ�Ƃ��ɌĂ΂��C�x���g
        // �I�u�W�F�N�g�̌��݈ʒu�ƃ}�E�X�N���b�N�ʒu�̍������I�t�Z�b�g�ɕۑ�
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true; // �h���b�O�t���O��L���ɂ���
    }

    void OnMouseUp()
    {
        // �}�E�X�{�^���������ꂽ�Ƃ��ɌĂ΂��C�x���g
        isDragging = false; // �h���b�O�t���O�𖳌��ɂ���
    }

    void Update()
    {
        if (isDragging)
        {
            // �h���b�O���̏���
            // �}�E�X�̌��݈ʒu�ɃI�t�Z�b�g�������ĐV�����ʒu���v�Z���A�I�u�W�F�N�g�̈ʒu���X�V
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = newPosition;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        // �}�E�X�̃X�N���[�����W�����[���h���W�ɕϊ�
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = specificCamera.transform.position.z;
        return specificCamera.ScreenToWorldPoint(mousePosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            Debug.Log("�������");
            //key.SetActive(false);
            Portao.SetActive(false);
            collision.SetActive(false);
            stick.SetActive(false);
            GameManager.Instance.RouyaKeyGet = true;
            GameManager.Instance.RouyaKeyText = true;
            Debug.Log(GameManager.Instance.RouyaKeyGet);
        }
    }
}