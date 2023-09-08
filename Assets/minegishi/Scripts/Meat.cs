using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    GameManager GM;
    TextWriter text;

    [SerializeField] Transform meat;


    //public bool meatText = false;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (GameManager.Instance.MeatGet)
        {
            meat.transform.position = new Vector3(0, -5, 0);
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
                    if (hit.collider.gameObject.name == "Meat")
                    {
                        GameManager.Instance.MeatGet = true;
                        GameManager.Instance.MeatText = true;
                        Debug.Log("meat");
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
