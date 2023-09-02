using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxUnlock : MonoBehaviour
{
    [SerializeField] GameObject Juwel1;
    [SerializeField] GameObject Juwel2;
    [SerializeField] GameObject Juwel3;
    [SerializeField] GameObject Drawer;

    bool Unlock = false;
    private float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("3Ç¬èWÇ‹Ç¡ÇΩ");
        Juwel1.SetActive(false);
        Juwel2.SetActive(false);
        Juwel3.SetActive(false);

        Invoke("JuwelSet1", 1.0f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Key")
                {
                 // GameManager.Instance.SafeKey = true;
                  
                }
            }
        }
    }

    void JuwelSet1()
    {
        Juwel1.SetActive(true);
        Invoke("JuwelSet2", 1.0f);
    }

    void JuwelSet2()
    {
        Juwel2.SetActive(true);
        Invoke("JuwelSet3", 1.0f);
    }

    void JuwelSet3()
    {
        Juwel3.SetActive(true);
        StartCoroutine("DrawerOpen");
        //Invoke("DrawerOpen", 1.0f);
    }

    IEnumerator DrawerOpen()
    {
        for (int move = 0; move < 20; move++)
        {
            Drawer.transform.Translate(0,-0.03f,0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}

