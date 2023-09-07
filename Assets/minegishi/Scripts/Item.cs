using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] GameObject meatImag;
    [SerializeField] GameObject stickImag;
    [SerializeField] GameObject rouyaKeyImag;
    [SerializeField] GameObject juwel1Imag;
    [SerializeField] GameObject juwel2Imag;
    [SerializeField] GameObject juwel3Imag;
    [SerializeField] GameObject safekeyImag;
    [SerializeField] GameObject exitkeyImag;

    SafeKey safekey;
    ExitKey exitkey;


    void Start()
    {
        //safekey = GameObject.Find("SafeKey").GetComponent<SafeKey>();
        //exitkey = GameObject.Find("ExitKey").GetComponent<ExitKey>();
    }


    void Update()
    {
        //肉を手に入れたら表示する
        if (GameManager.Instance.MeatGet)
        {
            meatImag.SetActive(true);
        }
        //肉を使ったら半透明にする
        if (GameManager.Instance.MeatUsed)
        {
            meatImag.GetComponent<CanvasGroup>().alpha = 0.3f;
        }

        //棒を手に入れたら表示する
        if (GameManager.Instance.StickGet)
        {
            stickImag.SetActive(true);
        }
        //棒を使ったら半透明にする
        if (GameManager.Instance.StickUsed)
        {
            stickImag.GetComponent<CanvasGroup>().alpha = 0.3f;
        }

        //牢屋のカギを手に入れたら表示する
        if (GameManager.Instance.RouyaKeyGet)
        {
            rouyaKeyImag.SetActive(true);
        }
        //牢屋のカギを使ったら半透明にする
        if (GameManager.Instance.RouyaKeyUsed)
        {
            rouyaKeyImag.GetComponent<CanvasGroup>().alpha = 0.3f;
        }

        //宝石１を手に入れたら表示する
        if (GameManager.Instance.Juwel1Get)
        {
            juwel1Imag.SetActive(true);
        }
        //宝石１を使ったら半透明にする
        if (GameManager.Instance.Juwel1Used)
        {
            juwel1Imag.GetComponent<CanvasGroup>().alpha = 0.3f;
        }

        //宝石２を手に入れたら表示する
        if (GameManager.Instance.Juwel2Get)
        {
            juwel2Imag.SetActive(true);
        }
        //宝石２を使ったら半透明にする
        if (GameManager.Instance.Juwel2Used)
        {
            juwel2Imag.GetComponent<CanvasGroup>().alpha = 0.3f;
        }

        //宝石３を手に入れたら表示する
        if (GameManager.Instance.Juwel3Get)
        {
            juwel3Imag.SetActive(true);
        }
        //宝石３を使ったら半透明にする
        if (GameManager.Instance.Juwel3Used)
        {
            juwel3Imag.GetComponent<CanvasGroup>().alpha = 0.3f;
        }

        //金庫のカギを手に入れたら表示する
        if (GameManager.Instance.SafeKeyGet == true) 
        {
            safekeyImag.SetActive(true);
        }
        //金庫のカギを使ったら半透明にする
        if(GameManager.Instance.SafeKeyUsed == true)
        {
            safekeyImag.GetComponent<CanvasGroup>().alpha = 0.3f;
        }

        //出口のカギを手に入れたら表示する
        if(GameManager.Instance.ExitKeyGet == true)
        {
            exitkeyImag.SetActive(true);
        }
        //出口のカギを使ったら半透明にする
        if (GameManager.Instance.ExitKeyUsed == true)
        {
            exitkeyImag.GetComponent<CanvasGroup>().alpha = 0.3f;
        } 
    }
}
