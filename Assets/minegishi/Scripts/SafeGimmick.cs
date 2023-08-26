using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGimmick : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject Drawer;
    private Vector3 safePos;

    [SerializeField] GameObject key;

    public bool safetext = false;
    public static bool open = false;


    TextWriter text;
    GameManager GM;
    SafeKey safekey;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        safekey = GameObject.Find("SafeKey").GetComponent<SafeKey>();
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
                        safetext = true;
                        GM.PlayMode = GameManager.Mode.Text;

                        StartCoroutine(text.Cotest());
                        if (SafeKey.safeKey)
                        {
                            open = true;
                            SafeKey.safeKeyUsed = true;
                            StartCoroutine("DrawerOpen");
                        }
                        
                        //key.transform.position = new Vector3(-29, -2.8f, 14.2f);
                        //key.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    IEnumerator DrawerOpen()
    {
        for (int move = 0; move < 30; move++)
        {
            Drawer.transform.Translate(0, -0.03f, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
