using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rouya : MonoBehaviour
{
    GameManager GM;

    [SerializeField] GameObject player;
    private Vector3 rouyaPos;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        Transform myTransform = this.transform;
        rouyaPos = myTransform.position;
        Vector3 playerpos = player.transform.position;　//playerの座標
        float dis = Vector3.Distance(rouyaPos, playerpos);

        if (GM.PlayMode == GameManager.Mode.Play)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "Rouya" && dis <= 9) 
                    {
                        GameManager.Instance.RouyaKeyUsed = true;
                        GameManager.Instance.RouyaText = true;
                        GM.PlayMode = GameManager.Mode.Text;

                        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
                        StartCoroutine(text.Cotest());
                    }
                }
            }
        }
    }
}
