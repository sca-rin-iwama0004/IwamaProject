using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGimmick : MonoBehaviour
{
    [SerializeField] GameObject key;

    static bool open = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Safe" && !open) //���ɂ��N���b�N
                {
                    Debug.Log("�N���b�N");
                    open = true;
                    key.gameObject.SetActive(true);

                }
            }
        }
    }
}
