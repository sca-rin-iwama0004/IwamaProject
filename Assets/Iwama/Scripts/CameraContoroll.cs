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
    [SerializeField] GameObject passD;//オブジェクトのダミー
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
        passD.SetActive(true); //テキスト表示させるため
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
                passD.SetActive(false);
                closeB.SetActive(true);
                passOn = true;//passを打ち終わったか
            }
        }
    }

   public void CloseButton()//閉じる(×)を押したとき
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