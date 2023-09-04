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
                float maxRayDistance = 4f; // Ray����ԍő�̋���

                if (Physics.Raycast(ray, out hit,maxRayDistance))
                {
                    if (hit.collider.gameObject.name == "Door") //�h�A���N���b�N
                    {
                        SceneManager.LoadScene("HiddenRoom");
                    }
                    if (hit.collider.gameObject.name == "VaultRoom") //�h�A���N���b�N
                    {
                        SceneManager.LoadScene("VaultRoom");
                    }
                    if (hit.collider.gameObject.name == "HallDoor") //�h�A���N���b�N
                    {
                        SceneManager.LoadScene("SampleScene");
                    }
                    //�ǉ��A��L�Ԃ���E����
                    if (hit.collider.gameObject.name == "RightRoom" && GameManager.Instance.RightKey) //�h�A���N���b�N
                    {
                        SceneManager.LoadScene("RightroomScene");
                    }

                    //�ǉ��A�S�������L��
                    if (hit.collider.gameObject.name == "GreatHallDoor" && GameManager.Instance.RouyaKeyGet) //�h�A���N���b�N
                    {
                        SceneManager.LoadScene("SampleScene");
                    }

                    //�ǉ��A�E���������L��
                    if (hit.collider.gameObject.name == "LeftDoor")
                    {
                        SceneManager.LoadScene("SampleScene");
                    }

                    if (hit.collider.gameObject.name == "ExitDoor" && GameManager.Instance.ExitDoorOpen) //�h�A���N���b�N
                    {
                        SceneManager.LoadScene("entranceScene");
                    }

                    if (hit.collider.gameObject.name == "PrisonRoom") //�h�A���N���b�N
                    {
                        SceneManager.LoadScene("rouyaScene");
                    }

                    if (hit.collider.gameObject.name == "EntranceDoor") //�h�A���N���b�N
                    {
                        SceneManager.LoadScene("SampleScene");
                    }
                }

            }
        }
    }
}
