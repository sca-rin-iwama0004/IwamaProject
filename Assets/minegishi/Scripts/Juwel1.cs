using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juwel1 : MonoBehaviour
{
    GameManager GM;
    TextWriter text;

    [SerializeField] Transform juwel;

    //public bool juwel1Text = false;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (GameManager.Instance.Juwel1Get)
        {
            juwel.transform.position = new Vector3(-2.6f, -5, -2);
        }
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
                    if (hit.collider.gameObject.name == "Juwel1")
                    {
                        GameManager.Instance.Juwel1Get = true;
                        GameManager.Instance.JuwelCount++;
                        GameManager.Instance.Juwel1Text = true;
                        Debug.Log("juwel1");
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
