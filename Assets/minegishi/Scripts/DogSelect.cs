using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogSelect : MonoBehaviour
{
    [SerializeField] GameObject Button;
    GameObject select3;

    public bool selectText1 = false; //犬の選択肢：そのまま通り過ぎる
    public bool selectText2 = false; //犬の選択肢：何もしない
    public bool selectText3 = false; //犬の選択肢：生肉を投げる


    public bool DogText = false;
    public bool entrance = false;

    GameManager GM;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (SceneManager.GetActiveScene().name == "HiddenRoom")
        {
            GM.PlayMode = GameManager.Mode.Text;
            DogText = true;
            TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
            StartCoroutine(text.Cotest());
            entrance = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "HiddenRoom" && entrance == false)
        {
            GM.PlayMode = GameManager.Mode.Text;
            entrance = true;
            DogText = true;
            TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
            StartCoroutine(text.Cotest());
        }
    }

    public IEnumerator Selection()
    {
        Button.SetActive(true);
        yield return 0;
    }

    public void SelectButton1() //選択肢：「そのまま通り過ぎる」を選択
    {
        Button.SetActive(false);
        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
        selectText1 = true;
        StartCoroutine(text.Cotest());
    }

    public void SelectButton2() //選択肢：「何もしない」を選択
    {
        Button.SetActive(false);
        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
        selectText2 = true;
        StartCoroutine(text.Cotest());
    }

    public void SelectButton3() //選択肢：「生肉を投げる」を選択
    {
        Button.SetActive(false);
        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
        selectText3 = true;
        StartCoroutine(text.Cotest());
    }
}
