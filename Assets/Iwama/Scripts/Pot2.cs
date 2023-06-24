using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot2 : MonoBehaviour
{
   bool Moveing = false;//カメラが動いているか
    bool nozoku = false;//覗くボタン押されたか
    public GameObject mainCamera;

    bool JuwelDestroy = false;//宝石を回収したか

    public GameObject Juwel;
   
    // Update is called once per frame
    void Update()
    {
        //メインカメラが非アクティブ状態だったとき
        //多分カメラがアップになってアイテム取るんじゃないか？
        //多分チェックボタンで対応していくと思う
        if (mainCamera.activeSelf == false)
        {
            //mainCameraがfalseの時は近くで見るを押されているとき
            //牢屋、右部屋で「中を覗く」系をを選択したとき
            if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.B) && !JuwelDestroy && nozoku)
                {
                    JuwelGet();
                }
                // ここにStartCoroutine("Rotate")みたいなのが来るんじゃ？;
            }

            //大広間で「中を覗く」を選択したとき
            if (Input.GetKey(KeyCode.C))
            {
                if((!Moveing && !nozoku))
                StartCoroutine("Rotate");
                Moveing = true;
            }
            if (Input.GetKey(KeyCode.A) && !JuwelDestroy && nozoku)
            {
                JuwelGet();
            }
            //消したらカウント1回だけ動く
            //boolたてなくちゃいけないfalse
        }
    }


    public void JuwelGet()
    {
        // 「宝石を取る」を押したとき
        //if (Input.GetKey(KeyCode.A) && !JuwelDestroy)
       // {
            //this.gameObjectだとだとだめだ
            // Destroy(this.gameObject);
            Destroy(this.gameObject);
        GameManager.Instance.JuwelCount++;
            Debug.Log(GameManager.Instance.JuwelCount);
            JuwelDestroy = true;
       // }
    }

    IEnumerator Rotate()//カメラを傾ける
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
