using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeKey : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Camera specificCamera;
    [SerializeField] Transform safekey;

    GameManager GM;
    TextWriter text;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (GameManager.Instance.SafeKeyGet)
        {
            safekey.transform.position = new Vector3(10000, 10000, 10000);
        }
    }

    void Update()
    {
        if (GM.PlayMode == GameManager.Mode.Play)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = specificCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "SafeKey") //‹àŒÉ‚ÌŒ®‚ðƒNƒŠƒbƒN
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
