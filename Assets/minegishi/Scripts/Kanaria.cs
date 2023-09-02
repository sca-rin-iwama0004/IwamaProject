using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanaria : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 kanariaPos;

    //public static bool KanariaRescue = false;
    //public bool kanariaText = false;

    GameManager GM;
    TextWriter text;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        text = GameObject.Find("Text").GetComponent<TextWriter>();
    }

    void Update()
    {
        Transform myTransform = this.transform;
        kanariaPos = myTransform.position;
        Vector3 playerpos = player.transform.position;　//playerの座標
        float dis = Vector3.Distance(kanariaPos, playerpos);

        if (GM.PlayMode == GameManager.Mode.Play)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "kanaria" && dis <= 9) //カナリアをクリック
                    {
                        Debug.Log("kanaria");
                        GM.PlayMode = GameManager.Mode.Text;

                        GameManager.Instance.KanariaRescue = true;
                        GameManager.Instance.KanariaText = true;

                        StartCoroutine(text.Cotest());
                        
                    }
                }
            }
        }
    }
}
