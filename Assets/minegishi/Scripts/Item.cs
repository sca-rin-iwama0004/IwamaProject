using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] GameObject exitkeyImag;

    void Start()
    {
        ExitKey exitkey = GameObject.Find("ExitKey").GetComponent<ExitKey>();
    }


    void Update()
    {
        //出口のカギを手に入れたら表示する
        if(ExitKey.exitKey == true)
        {
            exitkeyImag.SetActive(true);
        }
        //出口のカギを使ったら半透明にする
        if (ExitKey.exitKeyUsed == true)
        {
            exitkeyImag.GetComponent<CanvasGroup>().alpha = 0.3f;
            Debug.Log("Used");
        } 
    }
}
