using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCloseButton : MonoBehaviour
{
    [SerializeField] GameObject mainC;
    [SerializeField] GameObject potC;//�|�b�g�̃J����
    [SerializeField] GameObject closeB;//����(�~)�{�^��
    [SerializeField] GameObject textB;//�ڂ������ׂ�{�^��
    Ray ray;

    void Start()
    {
        closeB.SetActive(false);
        potC.SetActive(false);
        textB.SetActive(false);

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            float maxRayDistance = 5f; // Ray����ԍő�̋���

            int potMask = 1 << 7;//�����o���ɐG�ꂽ�Ƃ�
            if (Physics.Raycast(ray, out hit, maxRayDistance, potMask))
            {
                mainC.SetActive(false);
                potC.SetActive(true);
                closeB.SetActive(true);
                textB.SetActive(true);
            }
        }
    }

    public void CloseButton()//����(�~)���������Ƃ�
    {
        Debug.Log("Before setting textB to false: " + textB.activeSelf);
        closeB.SetActive(false);
        mainC.SetActive(true);
        potC.SetActive(false);
        textB.SetActive(false);
        Debug.Log("After setting textB to false: " + textB.activeSelf);

    }
}
