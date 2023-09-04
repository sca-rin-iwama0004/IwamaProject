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
                float maxRayDistance = 4f; // Rayが飛ぶ最大の距離

                if (Physics.Raycast(ray, out hit,maxRayDistance))
                {
                    if (hit.collider.gameObject.name == "Door") //ドアをクリック
                    {
                        SceneManager.LoadScene("HiddenRoom");
                    }
                    if (hit.collider.gameObject.name == "VaultRoom") //ドアをクリック
                    {
                        SceneManager.LoadScene("VaultRoom");
                    }
                    if (hit.collider.gameObject.name == "HallDoor") //ドアをクリック
                    {
                        SceneManager.LoadScene("SampleScene");
                    }
                    //追加、大広間から右部屋
                    if (hit.collider.gameObject.name == "RightRoom" && GameManager.Instance.RightKey) //ドアをクリック
                    {
                        SceneManager.LoadScene("RightroomScene");
                    }

                    //追加、牢屋から大広間
                    if (hit.collider.gameObject.name == "GreatHallDoor" && GameManager.Instance.RouyaKeyGet) //ドアをクリック
                    {
                        SceneManager.LoadScene("SampleScene");
                    }

                    //追加、右部屋から大広間
                    if (hit.collider.gameObject.name == "LeftDoor")
                    {
                        SceneManager.LoadScene("SampleScene");
                    }

                    if (hit.collider.gameObject.name == "ExitDoor" && GameManager.Instance.ExitDoorOpen) //ドアをクリック
                    {
                        SceneManager.LoadScene("entranceScene");
                    }

                    if (hit.collider.gameObject.name == "PrisonRoom") //ドアをクリック
                    {
                        SceneManager.LoadScene("rouyaScene");
                    }

                    if (hit.collider.gameObject.name == "EntranceDoor") //ドアをクリック
                    {
                        SceneManager.LoadScene("SampleScene");
                    }
                }

            }
        }
    }
}
