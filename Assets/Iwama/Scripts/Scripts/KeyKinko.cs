using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyKinko : MonoBehaviour
{
    [SerializeField] GameObject houseki1;
    [SerializeField] GameObject houseki2;
    [SerializeField] GameObject houseki3;

    bool KeyKaijo = false;//GameManGerに書く？

    // Start is called before the first frame update
    void Start()
    {
        //ここにくるのはカメラアップ→宝石をはめるにしてから？
        Debug.Log("3つ集まった");
        
        houseki1.SetActive(false);
        houseki2.SetActive(false);
        houseki3.SetActive(false);

        Invoke("housekiSet1", 1.0f);
    }

    private void Update()
    {
        if (houseki3.activeSelf == true && Input.GetKey(KeyCode.Space) && !KeyKaijo)
        {
            Debug.Log("金庫を開ける");
            KeyKaijo = true;

        }
    }

    void housekiSet1()
    {
        houseki1.SetActive(true);
        Invoke("housekiSet2", 1.0f);
    }

    void housekiSet2()
    {
        houseki2.SetActive(true);
        Invoke("housekiSet3", 1.0f);
    }

    void housekiSet3()
    {
        houseki3.SetActive(true);
    }

}

