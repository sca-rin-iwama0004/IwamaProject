using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JuwelCountA : MonoBehaviour
{
    bool JuwelDestroy = false;//•óÎ‚ğ‰ñû‚µ‚½‚©
    public GameObject clickedGameObject;

    // Start is called before the first frame update
    void Start()
    {
        //•óÎ1‚ğ“üè‚µ‚Ä‚¢‚½‚ç
        if (GameManager.Instance.Juwel1Get)
        {
            Destroy(clickedGameObject);
        }
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;
                Destroy(clickedGameObject);
                GameManager.Instance.JuwelCount++;
                Debug.Log(GameManager.Instance.JuwelCount);
                JuwelDestroy = true;

                GameManager.Instance.Juwel1Get = true;
            }

            Debug.Log(clickedGameObject);
        }
    }
}