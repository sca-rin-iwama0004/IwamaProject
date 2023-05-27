using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitKey : MonoBehaviour
{
    public static bool exitKey　= false;
    public bool exitKeyText = false;

    GameManager GM;
    TextWriter text;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    
    void Update()
    {
        if(GM.PlayMode == GameManager.Mode.Play) { 
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "ExitKey") //出口の鍵をクリック
                    {
                        exitKey = true;
                        exitKeyText = true;
                        GM.PlayMode = GameManager.Mode.Text;

                        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
                        StartCoroutine(text.Cotest());
                        Destroy(this.gameObject);
                    }
                }
            }
            if(exitKey == true)
            {
                Debug.Log("GET!");
            }
        }
    }
}
