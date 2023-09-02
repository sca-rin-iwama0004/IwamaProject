using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeKey : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Camera specificCamera;

    private Vector3 safekeyPos;

    //public static bool safeKey = false;
    //public bool safeKeyText = false;
    //public static bool safeKeyUsed = false;

    GameManager GM;
    TextWriter text;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        Transform myTransform = this.transform;
        safekeyPos = myTransform.position;
        Vector3 playerpos = player.transform.position;　//playerの座標        
        float dis = Vector3.Distance(safekeyPos, playerpos);

        if (GM.PlayMode == GameManager.Mode.Play)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = specificCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "SafeKey") //金庫の鍵をクリック
                    {
                        GameManager.Instance.SafeKeyGet = true;
                        GameManager.Instance.SafeKeyText = true;
                        GM.PlayMode = GameManager.Mode.Text;

                        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
                        StartCoroutine(text.Cotest());
                    }
                }
            }
            //if (SafeGimmick.open == true && safeKey == false)
            //{
            //    this.gameObject.SetActive(true);
            //}
        }
    }
}
