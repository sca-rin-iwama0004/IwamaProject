using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraContoroll : MonoBehaviour
{
    [SerializeField] GameObject mainC;
    [SerializeField] GameObject potC;//ポットのカメラ
    [SerializeField] GameObject passC;//パスワードパネルのカメラ
    [SerializeField] GameObject passB;//パスワードのボタン
    [SerializeField] GameObject closeB;//閉じる(×)ボタン
    [SerializeField] GameObject textB;//詳しく調べるボタン
    Ray ray;

    bool passOn = false;

    // Start is called before the first frame update
    void Start()
    {
       closeB.SetActive(false);
       potC.SetActive(false);
        textB.SetActive(false);
        passC.SetActive(false);
       passB.SetActive(false);
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            int potMask = 1 << 7;//ポッドに触れたとき
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, potMask))
            {
                mainC.SetActive(false);
                potC.SetActive(true);
                closeB.SetActive(true);
                textB.SetActive(true);
            }

            int passMask = 1 << 9;//パスワードパネルに触れたとき
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, passMask) && !passOn)
            {
                mainC.SetActive(false);
                passC.SetActive(true);
                passB.SetActive(true);
                closeB.SetActive(true);
                passOn = true;//これは要る？
            }
        }
    }

   public void CloseButton()//閉じる(×)を押したとき
    {
        closeB.SetActive(false);
        mainC.SetActive(true);
        potC.SetActive(false);
        passC.SetActive(false);
        passB.SetActive(false);
        textB.SetActive(false);
        passOn = false;
      
    }
}