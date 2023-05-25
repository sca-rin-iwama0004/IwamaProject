using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGimmick : MonoBehaviour
{
    [SerializeField] GameObject key;

    public bool safetext = false;
    static bool open = false;

    public TextWriter text;

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
                if (hit.collider.gameObject.name == "Safe" && !open) //‹àŒÉ‚ðƒNƒŠƒbƒN
                {
                    TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
                    Debug.Log("open");
                    safetext = true;
                    open = true;
                    Debug.Log(safetext);
                    StartCoroutine(text.Cotest());
                    key.gameObject.SetActive(true);

                }
            }
        }
    }
}
