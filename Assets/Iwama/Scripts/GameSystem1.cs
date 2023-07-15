using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem1 : MonoBehaviour
{
    GameManager GM;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        ExitDoor exitdoor = GameObject.Find("ExitDoor").GetComponent<ExitDoor>();
    }

    
    void Update()
    {
        if(GM.PlayMode == GameManager.Mode.Play) { 
            if (Input.GetMouseButtonDown(0))
            {
                //clickedGameObject = null;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "Door") //�h�A���N���b�N
                    {
                        Debug.Log("�V�[���ړ�");
                        SceneManager.LoadScene("HiddenRoom");
                    }
                    if (hit.collider.gameObject.name == "VaultRoom") //�h�A���N���b�N
                    {
                        Debug.Log("�V�[���ړ�");
                        SceneManager.LoadScene("VaultRoom");
                    }
                    if (hit.collider.gameObject.name == "GreatHallDoor") //�h�A���N���b�N
                    {
                        Debug.Log("�V�[���ړ�");
                        SceneManager.LoadScene("SampleScene");
                    }

                    if (hit.collider.gameObject.name == "ExitDoor" && ExitDoor.open) //�h�A���N���b�N
                    {
                        Debug.Log("�V�[���ړ�");
                        SceneManager.LoadScene("entranceScene");
                    }

                    //�ǉ�
                    if (hit.collider.gameObject.name == "RightRoom" ) //�h�A���N���b�N
                    {
                        if (GameManager.Instance.RightKey)//�E�����̌����J���Ă�����
                        {
                            SceneManager.LoadScene("RightroomScene");
                            Debug.Log("�V�[���ړ�");
                        }
                    }

                    //�ǉ�
                    if (hit.collider.gameObject.name == "LeftDoor") //�h�A���N���b�N
                    {
                        Debug.Log("�V�[���ړ�");
                        SceneManager.LoadScene("SampleScene");
                    }
                }
            }
        }
    }
}
