using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    bool Moveing = false;//カメラが動いているか
    bool search = false;//詳しく調べるを押しているか
 
    public GameObject mainCamera;

    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
         
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
        search = true; 
    }

    public void searchButton()//更に調べるを押したとき
    {
        if (!Moveing && !search)
        {
            StartCoroutine("Rotate");
            Moveing = true;
        }
    }
}
