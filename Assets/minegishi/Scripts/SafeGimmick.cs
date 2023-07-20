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


    TextWriter text;
    GameManager GM;
    ExitKey exitkey;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        exitkey = GameObject.Find("ExitKey").GetComponent<ExitKey>();
        text = GameObject.Find("Text").GetComponent<TextWriter>();
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

                        safetext = true;
                        open = true;

                        StartCoroutine(text.Cotest());
                        key.transform.position = new Vector3(-29, -2.8f, 14.2f);
                        //key.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
