using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIText : MonoBehaviour
{
    public Text nameText; //しゃべっている人の名前
    public Text talkText; //しゃべっている内容

    public bool playing = false;
    public float textSpeed = 0.1f;

    private static bool created = false;

    void Start()
    {
        if (!created)
        {
            created = true;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this.gameObject);
    }

    // クリックで次のページを表示させるための関数
    public bool IsClicked()
    {
        if (Input.GetMouseButtonDown(0)) return true;
        return false;
    }

    // ナレーション用のテキストを生成する関数
    public void DrawText(string text)
    {
        StartCoroutine("CoDrawText", text);
    }

    // 通常会話用のテキストを生成する関数
    public void DrawText(string name, string text)
    {
        nameText.text = name;
        StartCoroutine("CoDrawText", text + "」");
    }

    // テキストがヌルヌル出てくるためのコルーチン
    public IEnumerator CoDrawText(string text)
    {
        playing = true;
        float time = 0;
        while (true)
        {
            yield return 0;
            time += Time.deltaTime;

            // クリックされると一気に表示
            if (IsClicked()) break;

            int len = Mathf.FloorToInt(time / textSpeed);
            if (len > text.Length) break;
            talkText.text = text.Substring(0, len);
        }
        talkText.text = text;
        yield return 0;
        playing = false;
    }
}