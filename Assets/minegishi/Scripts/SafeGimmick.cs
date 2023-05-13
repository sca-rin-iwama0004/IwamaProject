using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGimmick : MonoBehaviour
{
    private GameObject key;
    void Start()
    {
        key = GameObject.Find("Key");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Safe") //金庫をクリック
                {
                    Debug.Log("クリック");
                    
                }
            }
        }
    }
}
