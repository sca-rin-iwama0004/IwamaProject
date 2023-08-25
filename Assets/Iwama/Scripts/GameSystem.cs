using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    GameManager GM;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        ExitDoor exitdoor = GameObject.Find("ExitDoor").GetComponent<ExitDoor>();
    }

    
    void Update()
    {
        if (GM.PlayMode == GameManager.Mode.Play)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //clickedGameObject = null;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "Door") //ドアをクリック
                    {
                        SceneManager.LoadScene("HiddenRoom");
                    }
                    if (hit.collider.gameObject.name == "VaultRoom") //ドアをクリック
                    {
                        SceneManager.LoadScene("VaultRoom");
                    }
                    //追加、大広間から右部屋
                    if (hit.collider.gameObject.name == "RightRoom" && GameManager.Instance.RightKey) //ドアをクリック
                    {
                        SceneManager.LoadScene("RightroomScene");
                    }

                    //追加、牢屋から大広間
                    if (hit.collider.gameObject.name == "GreatHallDoor" && GameManager.Instance.GreathellKey) //ドアをクリック
                    {
                        SceneManager.LoadScene("SampleScene");
                    }

                    //追加、右部屋から大広間
                    if (hit.collider.gameObject.name == "LeftDoor") 
                    {
                        SceneManager.LoadScene("SampleScene");
                    }

                    if (hit.collider.gameObject.name == "ExitDoor" && ExitDoor.open) //ドアをクリック
                    {
                        SceneManager.LoadScene("entranceScene");
                    }
                }

            }
        }
    }
}
