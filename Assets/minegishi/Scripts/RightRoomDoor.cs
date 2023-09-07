using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRoomDoor : MonoBehaviour
{
    GameManager GM;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (GM.PlayMode == GameManager.Mode.Play)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                float maxRayDistance = 4f; // Rayが飛ぶ最大の距離

                if (Physics.Raycast(ray, out hit, maxRayDistance))
                {
                    if (hit.collider.gameObject.name == "RightRoom" && !GameManager.Instance.RightKey)
                    {
                        GameManager.Instance.RightText = true;
                        GM.PlayMode = GameManager.Mode.Text;

                        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
                        StartCoroutine(text.Cotest());
                        //if (GameManager.Instance.ExitKeyGet)
                        //{
                        //    GameManager.Instance.ExitDoorOpen = true;
                        //    GameManager.Instance.ExitKeyUsed = true;
                        //}
                    }
                }
            }
        }
    }
}
