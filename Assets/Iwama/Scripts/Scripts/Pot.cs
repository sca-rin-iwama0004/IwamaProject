using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    bool Moveing = false;//カメラが動いているか
    bool nozoku = false;//Aボタン押されたか
 
    public GameObject Juwel;

    public GameObject mainCamera;
    bool A_Destroy = false;

    void Start()
    {
        //宝石1を入手していたら
        if (GameManager.Instance.Juwel2Get)
        {
            Destroy(Juwel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //メインカメラが非アクティブ状態だったとき
        if (mainCamera.activeSelf == false)
        {
            //選択肢(中をのぞく)が表示されたとき
            if (Input.GetKey(KeyCode.C))
            {
                if (!Moveing && !nozoku)
                    StartCoroutine("Rotate");
                     Moveing = true;
            }

            if (nozoku)//宝石を取るを押したとき
            {
                if (Input.GetKey(KeyCode.D) && !A_Destroy)
                {
                    GameManager.Instance.JuwelCount++;
                    Destroy(Juwel);
                    Debug.Log(GameManager.Instance.JuwelCount);
                    A_Destroy = true;
                    GameManager.Instance.Juwel2Get = true;
                }
            }
            //消したらカウント1回だけ動く
            //boolたてなくちゃいけないfalse
        }
        
    }

    IEnumerator Rotate()
    {
        for (int turn = 0; turn < 70; turn++)
        {
            transform.Rotate(1, 0, 0);
            yield return new WaitForSeconds(0.02f);
            //一度きりの処理、制御
        }
        Moveing = false;
        nozoku = true;
        
    }
 }

//RotateをmainCameraのときは作動しないようにしたい。