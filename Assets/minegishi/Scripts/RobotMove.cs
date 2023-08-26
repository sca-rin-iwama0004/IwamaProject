using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotMove : MonoBehaviour
{
    GameManager GM;
    TextWriter text;

    public bool robotText = false;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "VaultRoom" && PasswordPanel1.ans == false)
        {
            GM.PlayMode = GameManager.Mode.Text;

            robotText = true;
            //TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
            StartCoroutine(text.Cotest());
        }
    }
}
