using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
   [SerializeField] GameObject panel;

    GameManager GM;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(GM.PlayMode == GameManager.Mode.Play)
        {
            panel.SetActive(true);
        }else
            panel.SetActive(false);
    }
}
