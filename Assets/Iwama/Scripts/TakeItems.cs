using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TakeItems : MonoBehaviour
{

    GameObject clickedGameObject;
    Ray ray;

    public Camera specificCamera;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           ray = specificCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit = new RaycastHit();
            int mask = 1 << 6;//Ž}‚©“÷‚É‚µ‚©ray‚ª“–‚½‚ç‚È‚¢‚æ‚¤‚É

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                clickedGameObject = hit.collider.gameObject;

                if (clickedGameObject.name == "Stick")
                {
                    GameManager.Instance.StickGet = true;
                }

                if (clickedGameObject.name == "Meat")
                {
                    GameManager.Instance.MeatGet = true;
                }

                Destroy(clickedGameObject);
              
            }
            //Debug.Log(clickedGameObject);
        }
    }
}