using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juwel2 : MonoBehaviour
{
    GameManager GM;
    TextWriter text;

    public Camera specificCamera;

    //public bool juwel2Text = false;

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
                Ray ray = specificCamera.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit = new RaycastHit();
                float maxRayDistance = 5f; // RayÇ™îÚÇ‘ç≈ëÂÇÃãóó£
                int mask = 1 << 3;//JuwelÇ…ÇµÇ©rayÇ™ìñÇΩÇÁÇ»Ç¢ÇÊÇ§Ç…

                if (Physics.Raycast(ray, out hit, maxRayDistance, mask))
                {
                    if (hit.collider.gameObject.name == "Juwel2")
                    {
                        GameManager.Instance.Juwel2Get = true;
                        GameManager.Instance.JuwelCount++;
                        GameManager.Instance.Juwel2Text = true;
                        Debug.Log("juwel2");
                        GM.PlayMode = GameManager.Mode.Text;
                        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
                        StartCoroutine(text.Cotest());
                    }
                    //Destroy(clickedGameObject);

                }
                //Debug.Log(clickedGameObject);
            }
        }
    }
}
