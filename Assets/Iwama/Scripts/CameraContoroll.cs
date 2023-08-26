using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraContoroll : MonoBehaviour
{
    [SerializeField] GameObject mainC;
    [SerializeField] GameObject potC;//�|�b�g�̃J����
    [SerializeField] GameObject passC;//�p�X���[�h�p�l���̃J����
    [SerializeField] GameObject passB;//�p�X���[�h�̃{�^��
    [SerializeField] GameObject passD;//�I�u�W�F�N�g�̃_�~�[
    [SerializeField] GameObject closeB;//����(�~)�{�^��
    [SerializeField] GameObject textB;//�ڂ������ׂ�{�^��
    Ray ray;

    bool passOn = false;

    // Start is called before the first frame update
    void Start()
    {
       closeB.SetActive(false);
       potC.SetActive(false);
        textB.SetActive(false);
        passC.SetActive(false);
        passD.SetActive(true); //�e�L�X�g�\�������邽��
       passB.SetActive(false);
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            int potMask = 1 << 7;//�|�b�h�ɐG�ꂽ�Ƃ�
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, potMask))
            {
                mainC.SetActive(false);
                potC.SetActive(true);
                closeB.SetActive(true);
                textB.SetActive(true);
            }

            int passMask = 1 << 9;//�p�X���[�h�p�l���ɐG�ꂽ�Ƃ�
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, passMask) && !passOn)
            {
                mainC.SetActive(false);
                passC.SetActive(true);
                passB.SetActive(true);
                passD.SetActive(false);
                closeB.SetActive(true);
                passOn = true;//pass��ł��I�������
            }
        }
    }

   public void CloseButton()//����(�~)���������Ƃ�
    {
        Debug.Log("Before setting textB to false: " + textB.activeSelf);
        closeB.SetActive(false);
        mainC.SetActive(true);
        potC.SetActive(false);
        passC.SetActive(false);
        passD.SetActive(true);
        passB.SetActive(false);
        textB.SetActive(false);
        passOn = false;
        Debug.Log("After setting textB to false: " + textB.activeSelf);

    }
}