using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitKey : MonoBehaviour
{
    bool exitKey　= false;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "ExitKey") //出口の鍵をクリック
                {
                    Destroy(this.gameObject);
                    exitKey = true;
                }
            }
        }
        if(exitKey == true)
        {
            Debug.Log("GET!");
        }
    }
}
