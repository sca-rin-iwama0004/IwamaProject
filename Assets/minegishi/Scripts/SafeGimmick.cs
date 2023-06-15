using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGimmick : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 safePos;

    [SerializeField] GameObject key;

    public bool safetext = false;
    public static bool open = false;

    public TextWriter text;
    GameManager GM;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        Transform myTransform = this.transform;
        safePos = myTransform.position;
        Vector3 playerpos = player.transform.position;　//playerの座標        
        float dis = Vector3.Distance(safePos, playerpos);

        if (GM.PlayMode == GameManager.Mode.Play) { 
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "Safe" && !open && dis <= 9) //金庫をクリック
                    {
                        Debug.Log("open");
                        GM.PlayMode = GameManager.Mode.Text;

                        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
                        
                        safetext = true;
                        open = true;

                        StartCoroutine(text.Cotest());
                        key.gameObject.SetActive(true);

                    }
                }
            }
        }
    }
}
