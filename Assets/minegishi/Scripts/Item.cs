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
        if(ExitKey.exitKey == true)
        {
            exitkeyImag.SetActive(true);
        }
        if(ExitKey.exitKeyUsed == true)
        {
            exitkeyImag.GetComponent<CanvasGroup>().alpha = 0.5f;
        } 
    }
}
