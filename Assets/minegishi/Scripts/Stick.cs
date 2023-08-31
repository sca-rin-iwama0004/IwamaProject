using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    GameManager GM;
    TextWriter text;

    public bool stickText = false;

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

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "Stick")
                    {
                        GameManager.Instance.StickGet = true;
                        stickText = true;
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
