using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualBook : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 manualPos;
    public bool manualtext = false;

    GameManager GM;
    TextWriter text;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    void Update()
    {
        Transform myTransform = this.transform;
        manualPos = myTransform.position;
        Vector3 playerpos = player.transform.position;Å@//playerÇÃç¿ïW
        float dis = Vector3.Distance(manualPos, playerpos);

        if (GM.PlayMode == GameManager.Mode.Play)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "ManualBook" && dis <= 49)
                    {
                        GM.PlayMode = GameManager.Mode.Text;
                        manualtext = true;

                        text = GameObject.Find("Text").GetComponent<TextWriter>();
                        StartCoroutine(text.Cotest());
                    }
                }
            }
        }
    }
}
