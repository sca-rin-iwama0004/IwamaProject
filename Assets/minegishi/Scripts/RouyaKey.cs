using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouyaKey : MonoBehaviour
{
    GameManager GM;
    TextWriter text;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
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
