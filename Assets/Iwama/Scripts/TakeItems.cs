using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TakeItems : MonoBehaviour
{

    GameObject clickedGameObject;
    Ray ray;

    public Camera specificCamera;

    GameManager GM;
    TextWriter text;

    public bool stickText = false;
    public bool meatText = false; 

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    void Update()
    {
        if (GM.PlayMode == GameManager.Mode.Play)
        {
            if (Input.GetMouseButtonDown(0))
            {
               ray = specificCamera.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit = new RaycastHit();
                float maxRayDistance = 1f; // RayÇ™îÚÇ‘ç≈ëÂÇÃãóó£
                int mask = 1 << 6;//é}Ç©ì˜Ç…ÇµÇ©rayÇ™ìñÇΩÇÁÇ»Ç¢ÇÊÇ§Ç…

                if (Physics.Raycast(ray, out hit, maxRayDistance, mask))
                {
                    clickedGameObject = hit.collider.gameObject;

                    if (clickedGameObject.name == "Stick")
                    {
                        GameManager.Instance.StickGet = true;
                        stickText = true;
                    }

                    if (clickedGameObject.name == "Meat")
                    {
                        GameManager.Instance.MeatGet = true;
                        meatText = true;
                    }

                    GM.PlayMode = GameManager.Mode.Text;
                    TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
                    StartCoroutine(text.Cotest());

                    //Destroy(clickedGameObject);
              
                }
                //Debug.Log(clickedGameObject);
            }
        }
    }
}