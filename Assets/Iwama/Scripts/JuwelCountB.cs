using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class JuwelCountB : MonoBehaviour
{
    bool JuwelDestroy = false;//��΂����������
    public GameObject clickedGameObject;

    // Start is called before the first frame update
    void Start()
    {
        //���1����肵�Ă�����
        if (GameManager.Instance.Juwel3Get)
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

                GameManager.Instance.Juwel3Get = true;
            }

            Debug.Log(clickedGameObject);
        }
    }
}