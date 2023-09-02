using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    //public static ExitDoor instance = null;

    //public static bool open = false;
    //public bool opentext = false;

    GameManager GM;
    //TextWriter text;

    //private bool opentext = false;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        //ExitKey exitkey = GameObject.Find("ExitKey").GetComponent<ExitKey>();
    }


    void Update()
    {
        if (GM.PlayMode == GameManager.Mode.Play)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "ExitDoor" && !GameManager.Instance.ExitDoorOpen)
                    {
                        GameManager.Instance.ExitDoorText = true;
                        GM.PlayMode = GameManager.Mode.Text;

                        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
                        StartCoroutine(text.Cotest());
                        if (GameManager.Instance.ExitKeyGet)
                        {
                            GameManager.Instance.ExitDoorOpen = true;
                            GameManager.Instance.ExitKeyUsed = true;
                        }
                    }
                }
            }
        }
    }


}
