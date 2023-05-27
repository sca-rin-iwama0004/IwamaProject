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
                    if (hit.collider.gameObject.name == "Door") //ドアをクリック
                    {
                        Debug.Log("シーン移動");
                        SceneManager.LoadScene("Hidden Room");
                    }
                    if (hit.collider.gameObject.name == "Vault Room") //ドアをクリック
                    {
                        Debug.Log("シーン移動");
                        SceneManager.LoadScene("Vault Room");
                    }
                }
            }
        }
    }
}
