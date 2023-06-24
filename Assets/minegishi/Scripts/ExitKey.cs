using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitKey : MonoBehaviour
{
    [SerializeField] GameObject player;

    private Vector3 exitkeyPos;

    public static bool exitKey　= false;
    public bool exitKeyText = false;
    public static bool exitKeyUsed = false;

    GameManager GM;
    TextWriter text;
    //SafeGimmick safe;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        SafeGimmick safe = GameObject.Find("Safe").GetComponent<SafeGimmick>();
        
    }

    
    void Update()
    {
        Transform myTransform = this.transform;
        exitkeyPos = myTransform.position;
        Vector3 playerpos = player.transform.position;　//playerの座標        
        float dis = Vector3.Distance(exitkeyPos, playerpos);

        if (GM.PlayMode == GameManager.Mode.Play) { 
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "ExitKey" && dis <= 9) //出口の鍵をクリック
                    {
                        exitKey = true;
                        exitKeyText = true;
                        GM.PlayMode = GameManager.Mode.Text;

                        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
                        StartCoroutine(text.Cotest());
                    }
                }
            }
            if (SafeGimmick.open == true && exitKey == false)
            {
                this.gameObject.SetActive(true);
            }
        }
    }
}
