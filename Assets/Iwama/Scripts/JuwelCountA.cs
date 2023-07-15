using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class JuwelCountA : MonoBehaviour
{
    GameObject clickedGameObject;
    GameObject lostObj;
    public Camera specificCamera;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        //宝石を入手していたら
        if (GameManager.Instance.Juwel1Get)
        {
            lostObj = GameObject.Find("Juwel1");
            Destroy(lostObj);
        }
        else if(GameManager.Instance.Juwel2Get)
        {
            lostObj = GameObject.Find("Juwel2");
            Destroy(lostObj);
        }
        else if (GameManager.Instance.Juwel3Get)
        {
            lostObj = GameObject.Find("Juwel3");
            Destroy(lostObj);
        }

    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

          //  clickedGameObject = null;

            if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                ray = specificCamera.ScreenPointToRay(Input.mousePosition);
            }
            else {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }
           
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
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

            Debug.Log(clickedGameObject);
           // Debug.Log(GameManager.Instance.Juwel1Get);
            Debug.Log(GameManager.Instance.Juwel2Get);
        }
    }
}

//フラグ管理しても宝石が出てきてしまう、カメラの回転に制限がかからない