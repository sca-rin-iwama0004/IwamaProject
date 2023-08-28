using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickGimmck : MonoBehaviour
{
    [SerializeField] GameObject mainC;
    [SerializeField] GameObject prisonC;//牢屋のカメラ
    [SerializeField] GameObject closeB;//閉じる(×)ボタン
    [SerializeField] GameObject stick;//動かす枝
    float stickPosZ;                     
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        closeB.SetActive(false);
        prisonC.SetActive(false);
        stick.SetActive(false);
        stickPosZ = stick.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //ray = specificCamera.ScreenPointToRay(Input.mousePosition);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            int potMask = 1 << 7;//牢屋に触れたとき
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, potMask))
            {
                mainC.SetActive(false);
                prisonC.SetActive(true);
                closeB.SetActive(true);

                if (GameManager.Instance.StickGet)
                {
                    stick.SetActive(true);
                }
            }
        }
}

    public void CloseButton()//閉じる(×)を押したとき
    {
        closeB.SetActive(false);
        mainC.SetActive(true);
        prisonC.SetActive(false);
    }
}