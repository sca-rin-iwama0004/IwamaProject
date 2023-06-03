using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuwelCount : MonoBehaviour
{
    bool JuwelDestroy = false;//宝石を回収したか
    public GameObject Juwel;

    // Start is called before the first frame update
    void Start()
    {
        //宝石1を入手していたら
        if (GameManager.Instance.Juwel1Get)
        {
            Destroy(Juwel);
        }
         
    }

    // Update is called once per frame
    void Update()
    {
        // 「宝石を取る」を押す
        if (Input.GetKey(KeyCode.A) && !JuwelDestroy)
        {
            Destroy(Juwel);
            GameManager.Instance.JuwelCount++;
            Debug.Log(GameManager.Instance.JuwelCount);
            JuwelDestroy = true;
            GameManager.Instance.Juwel1Get = true;
        }
    }
}



//部屋を行き来しても取ったら取ったままにしたいからboolをgameManagerでgetsetして
//このスクリプトのStatedeでもしboolがあったら削除する？