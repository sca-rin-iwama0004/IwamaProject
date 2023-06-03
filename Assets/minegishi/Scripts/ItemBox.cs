using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
   [SerializeField] GameObject panel;

    GameManager GM;

    private static bool created = false;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (!created)
        {
            created = true;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this.gameObject);
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
