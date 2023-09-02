using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] GameObject meatImag;
    [SerializeField] GameObject stickImag;
    [SerializeField] GameObject juwel1Imag;
    [SerializeField] GameObject juwel2Imag;
    [SerializeField] GameObject safekeyImag;
    [SerializeField] GameObject exitkeyImag;

    SafeKey safekey;
    ExitKey exitkey;


    void Start()
    {
        safekey = GameObject.Find("SafeKey").GetComponent<SafeKey>();
        exitkey = GameObject.Find("ExitKey").GetComponent<ExitKey>();
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

        //金庫のカギを手に入れたら表示する
        if (SafeKey.safeKey == true) 
        {
            safekeyImag.SetActive(true);
        }
        //金庫のカギを使ったら半透明にする
        if(SafeKey.safeKeyUsed == true)
        {
            safekeyImag.GetComponent<CanvasGroup>().alpha = 0.3f;
        }

        //出口のカギを手に入れたら表示する
        if(ExitKey.exitKey == true)
        {
            exitkeyImag.SetActive(true);
        }
        //出口のカギを使ったら半透明にする
        if (ExitKey.exitKeyUsed == true)
        {
            exitkeyImag.GetComponent<CanvasGroup>().alpha = 0.3f;
        } 
    }
}
