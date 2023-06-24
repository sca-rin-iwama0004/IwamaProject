using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDoor : MonoBehaviour
{
    public static bool open = false;
    public bool opentext = false;

    GameManager GM;
    TextWriter text;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        ExitKey exitkey = GameObject.Find("ExitKey").GetComponent<ExitKey>();
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
                    if (hit.collider.gameObject.name == "ExitDoor" && !open)
                    {
                        opentext = true;
                        GM.PlayMode = GameManager.Mode.Text;

                        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
                        StartCoroutine(text.Cotest());
                        if (ExitKey.exitKey)
                        {
                            open = true;
                            ExitKey.exitKeyUsed = true;
                        }
                    }
                }
            }
        }
    }
}
