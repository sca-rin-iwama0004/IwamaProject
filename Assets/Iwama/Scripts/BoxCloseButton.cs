using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCloseButton : MonoBehaviour
{
    [SerializeField] GameObject mainC;
    [SerializeField] GameObject potC;//ポットのカメラ
    [SerializeField] GameObject closeB;//閉じる(×)ボタン
    [SerializeField] GameObject textB;//詳しく調べるボタン
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
            float maxRayDistance = 5f; // Rayが飛ぶ最大の距離

            int potMask = 1 << 7;//引き出しに触れたとき
            if (Physics.Raycast(ray, out hit, maxRayDistance, potMask))
            {
                mainC.SetActive(false);
                potC.SetActive(true);
                closeB.SetActive(true);
                textB.SetActive(true);
            }
        }
    }

    public void CloseButton()//閉じる(×)を押したとき
    {
        Debug.Log("Before setting textB to false: " + textB.activeSelf);
        closeB.SetActive(false);
        mainC.SetActive(true);
        potC.SetActive(false);
        textB.SetActive(false);
        Debug.Log("After setting textB to false: " + textB.activeSelf);

    }
}
