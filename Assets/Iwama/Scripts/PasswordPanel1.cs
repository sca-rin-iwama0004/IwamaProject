using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PasswordPanel1 : MonoBehaviour
{
    GameManager GM;
    TextWriter text;

    public bool anstext = false;
    public static bool ans = false;

    // アルファベットの入力を入れる配列
    [SerializeField] string[] input;
    // 正解のアルファベットを入れる配列
    [SerializeField] string[] collect;
    // 入力inputの添字
    int index;
    // 正解時に発生させるイベント
    public UnityEvent someEvent;
    // inputの内容を表示するためのテキスト。TextMeshProを利用。
    [SerializeField] TMP_Text displayText;


    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        //text = GameObject.Find("Text").GetComponent<TextWriter>();
        //開始時に初期化をする
        resetInput();
    }

    public void buttonInput(string alphabet)
    {
        //入力時点で４文字入力されていたら初期化する。
        if (index == 4)
        {
            resetInput();
        }

        //入力されたアルファベットを保存し、表示用テキストにも追加する
        input[index] = alphabet;
        displayText.text += alphabet;

        index++;

    }

    public void resetInput()
    {
        //表示用テキストとinput配列を空(null)にする
        displayText.text = null;
        index = 0;
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = null;
        }
    }

    public void isClear()
    {
        // OKボタンが押された時の処理
        // 正解チェックを行いイベントを発生させる
        if (checkPassword())
        {
            ans = true;
            Debug.Log("OK");
         //   someEvent.Invoke();
        }

        GM.PlayMode = GameManager.Mode.Text;
        text = GameObject.Find("Text").GetComponent<TextWriter>();
        anstext = true;
        StartCoroutine(text.Cotest());
        resetInput();
    }

    public bool checkPassword()
    {
        // １文字ずつ順番にチェックし１つでも間違いがあればFalseを返す。
        for (int i = 0; i < collect.Length; i++)
        {
            if (input[i] != collect[i])
            {
                return false;
            }
        }

        return true;
    }
}
//カメラの位置とかを変えたらキャンパスの位置とかも直す
//スクリプト自体は完成、動く
//OKだった時の処理(機械を止める)
//音を出す