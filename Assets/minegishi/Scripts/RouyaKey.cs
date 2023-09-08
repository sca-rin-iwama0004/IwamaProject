using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouyaKey : MonoBehaviour
{
    GameManager GM;
    TextWriter text;

    [SerializeField] Transform rouyaKey;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (GameManager.Instance.RouyaKeyGet)
        {
            rouyaKey.transform.position = new Vector3(2.7f, -5f, 3.5f);
        }
    }

    void Update()
    {
        if(GameManager.Instance.RouyaKeyText == true) { 
            GM.PlayMode = GameManager.Mode.Text;
            TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
            StartCoroutine(text.Cotest());
        }
    }
}
