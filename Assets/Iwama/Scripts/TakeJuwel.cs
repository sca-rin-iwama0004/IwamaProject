using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TakeJuwel : MonoBehaviour
{
   
    GameObject clickedGameObject;
   // public GameObject lostObj;
    public Camera specificCamera;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance.Juwel1Get = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //シーンによってカメラのrayを変更
           if (SceneManager.GetActiveScene().name == "SampleScene")
           {
                ray = specificCamera.ScreenPointToRay(Input.mousePosition);
           }
           else {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }
           
            RaycastHit hit = new RaycastHit();
            int mask = 1 << 3;//Juwelにしかrayが当たらないように

            if (Physics.Raycast(ray, out hit,Mathf.Infinity, mask))
            {
                clickedGameObject = hit.collider.gameObject;

                if(clickedGameObject.name == "Juwel1")
                {
                    GameManager.Instance.Juwel1Get = true;
                }
                else if(clickedGameObject.name == "Juwel2")
                {
                    GameManager.Instance.Juwel2Get = true;
                }
                else if (clickedGameObject.name == "Juwel3")
                {
                    GameManager.Instance.Juwel3Get = true;
                }
                Destroy(clickedGameObject);
                GameManager.Instance.JuwelCount++;
            }
            //Debug.Log(clickedGameObject);
        }
    }
}