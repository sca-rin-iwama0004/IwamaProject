using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextWriter : MonoBehaviour
{
    public UIText uitext;
    GameManager GM;

    //[SerializeField] GameObject meat;
    //[SerializeField] GameObject stick;
    //[SerializeField] GameObject juwel1;
    //[SerializeField] GameObject juwel2;
    //[SerializeField] GameObject juwel3;
    //[SerializeField] GameObject safekey;
    //[SerializeField] GameObject exitKey;
    //[SerializeField] GameObject kanaria;

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

    private void Update()
    {
        
    }
    // クリック待ちのコルーチン
    public IEnumerator Skip()
    {
        while (uitext.playing) yield return 0;
        while (!uitext.IsClicked()) yield return 0;
    }

    // 文章を表示させるコルーチン
    public IEnumerator Cotest()
    {
        if(GM.GameStartText == true) //ゲーム開始時のテキスト
        {
            uitext.DrawText("今日は主人が出かけているらしい");
            yield return StartCoroutine("Skip");
            uitext.DrawText("主人が帰ってくる前にこの屋敷から逃げ出そう！");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            GM.GameStartText = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        //if (prison.prisonkeytext == true) //牢屋の鍵のテキスト
        //{
        //    uitext.DrawText("牢屋の鍵を手に入れた");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    prisonkeytext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //    Destroy(prisonkey);
        //}

        //if(prison.prisontext == true && prison.prisonkey == false) //牢屋のテキスト
        //{
        //    uitext.DrawText("鍵がかかっている");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    prisontext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}
        //else if(prison.prisontext == true && prison.prisonkey == true)
        //{
        //    uitext.DrawText("牢屋の鍵を使った");
        //    yield return StartCoroutine("Skip");
        //    uitext.DrawText("鍵が開いた");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    prisontext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}
        //Debug.Log("text");
        Meat meat = GameObject.Find("Meat").GetComponent<Meat>();
        if (GameManager.Instance.MeatText == true) //肉のテキスト
        {
            uitext.DrawText("肉を手に入れた");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            GameManager.Instance.MeatText = false;
            GM.PlayMode = GameManager.Mode.Play;
            //Destroy(meat);
            meat.transform.position = new Vector3(0, -5, 0); //画面外に移動
        }

        Stick stick = GameObject.Find("Stick").GetComponent<Stick>();
        if (GameManager.Instance.StickText == true) //棒のテキスト
        {
            uitext.DrawText("棒を手に入れた");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            GameManager.Instance.StickText = false;
            GM.PlayMode = GameManager.Mode.Play;
            //Destroy(rod);
            stick.transform.position = new Vector3(-2.6f, -5, -2);　//画面外に移動
        }

        Juwel1 juwel1 = GameObject.Find("Juwel1").GetComponent<Juwel1>();
        if (GameManager.Instance.Juwel1Text == true) //宝石1のテキスト
        {
            uitext.DrawText("宝石を手に入れた");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            GameManager.Instance.Juwel1Text = false;
            GM.PlayMode = GameManager.Mode.Play;
            juwel1.transform.position = new Vector3(-2.6f, -5, -2); //画面外に移動
        }

        Juwel2 juwel2 = GameObject.Find("Juwel2").GetComponent<Juwel2>();
        if (GameManager.Instance.Juwel2Text == true) //宝石1のテキスト
        {
            uitext.DrawText("宝石を手に入れた");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            GameManager.Instance.Juwel2Text = false;
            GM.PlayMode = GameManager.Mode.Play;
            juwel2.transform.position = new Vector3(-2.6f, -5, -2); //画面外に移動
        }

        //if(statue.statuetext == true) //動かせない銅像のテキスト
        //{
        //    uitext.DrawText("像だ、もう一つの像と向かい合っている");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    statue.statuetext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}
        //if(statue.moveStatueText == true) //動かせる銅像のテキスト
        //{
        //    uitext.DrawText("像だ、……よく見るとボタンが付いていて動かせそうだ");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    statue.moveSatatueText = false;
        //}
        //if(statue.opentext == true) //銅像が向かい合った時
        //{
        //    uitext.DrawText("近くの部屋が開いたようだ");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    Statue.opentext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}

        //if(pot.pottext == true) //壺のテキスト
        //{
        //    uitext.DrawText("壺だ。良い品物に見える。");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    pot.pottext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}

        //ManualBook manual = GameObject.Find("ManualBook").GetComponent<ManualBook>();
        if (GameManager.Instance.ManualText == true) //看守用マニュアルのテキスト
        {
            uitext.DrawText("本棚の中から看守用マニュアルという本があった。");
            yield return StartCoroutine("Skip");
            uitext.DrawText("どうやら看守の設定などが書いてあるようだ。");
            yield return StartCoroutine("Skip");
            uitext.DrawText("最後のページに看守を止めるためのパスワードが書いてある。");
            yield return StartCoroutine("Skip");
            uitext.DrawText("3054……、覚えておこう。");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            GameManager.Instance.ManualText = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        PasswordPanel1 pas = GameObject.Find("ImagePanel").GetComponent<PasswordPanel1>();
        if (pas.anstext == true && PasswordPanel1.ans == false) //パスワードが不正解の時
        {
            uitext.DrawText("……何も起きない");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            pas.anstext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }
        if (pas.anstext == true && PasswordPanel1.ans == true) //パスワードが正解の時
        {
            uitext.DrawText("これで看守は止まったはずだ");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            pas.anstext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        //if(kinko.kinkotext == true && kinko.open == false) //右の部屋の金庫のテキスト
        //{
        //    uitext.DrawText("鍵がかかっている");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    kinkotext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}
        //else if(kinko.kinkotext == true && kinko.open == true)
        //{
        //    uitext.DrawText("宝石を３つはめた");
        //    yield return StartCoroutine("Skip");
        //    uitext.DrawText("鍵が開いた");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    kinkotext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}

        SafeKey safekey = GameObject.Find("SafeKey").GetComponent<SafeKey>();
        if (GameManager.Instance.SafeKeyText == true) //金庫の鍵のテキスト
        {
            uitext.DrawText("金庫の鍵を手に入れた");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            GameManager.Instance.SafeKeyText = false;
            GM.PlayMode = GameManager.Mode.Play;
            safekey.transform.position = new Vector3(10000, 10000, 10000);
        }

        //RobotMove robot = GameObject.Find("Robot").GetComponent<RobotMove>();
        if (GM.robotText) //ロボットのテキスト
        {
            uitext.DrawText("看守", "脱走者ハッケン");
            yield return StartCoroutine("Skip");
            uitext.DrawText(" ", "看守に見つかってしまった！");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            GM.robotText = false;
            GM.PlayMode = GameManager.Mode.end;
            SceneManager.LoadScene("gameoverScene");
        }

        //BookShelf bookshelf = GameObject.Find("bookcase").GetComponent<BookShelf>();
        if (GameManager.Instance.BookShelfText) //本棚のテキスト
        { 
            uitext.DrawText("本棚が動いた");
            yield return StartCoroutine("Skip");
            uitext.DrawText("扉が出てきた");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            GameManager.Instance.BookShelfText = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        Kanaria kanaria = GameObject.Find("kanaria").GetComponent<Kanaria>();
        if (GameManager.Instance.KanariaText)
        {
            uitext.DrawText("カナリアが囚われている");
            yield return StartCoroutine("Skip");
            uitext.DrawText("カナリアを助けた");
            yield return StartCoroutine("Skip");
            uitext.DrawText("カナリア", "「助けてくれてありがとう！」");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ", " ");
            GameManager.Instance.KanariaText = false;
            kanaria.transform.position = new Vector3(-16.75f, -10, 8);
            GM.PlayMode = GameManager.Mode.Play;
        }

        //SafeGimmick safe = GameObject.Find("Safe").GetComponent<SafeGimmick>();
        if (GameManager.Instance.SafeText == true && GameManager.Instance.SafeKeyGet == false)
        {
            uitext.DrawText("鍵がかかっている");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            GameManager.Instance.SafeText = false;
            GM.PlayMode = GameManager.Mode.Play;
        }
        else if (GameManager.Instance.SafeText == true && GameManager.Instance.SafeKeyGet == true) //金庫のテキスト
        {
            uitext.DrawText("金庫が開いた");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            GameManager.Instance.SafeText = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        ExitKey exitkey = GameObject.Find("ExitKey").GetComponent<ExitKey>();
        //GameObject exitKey = GameObject.Find("ExitKey");
        if (GameManager.Instance.ExitKeyText == true) //出口の鍵のテキスト
        {
            uitext.DrawText("出口の鍵を手に入れた");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            GameManager.Instance.ExitKeyText = false;
            GM.PlayMode = GameManager.Mode.Play;
            //Destroy(exitKey);
            exitkey.transform.position = new Vector3(-29, -20.8f, 10.9f); //画面外に移動
        }

        //ExitDoor exitdoor = GameObject.Find("ExitDoor").GetComponent<ExitDoor>();
        if (GameManager.Instance.ExitDoorText == true && GameManager.Instance.ExitKeyGet == false)　//出口のテキスト
        {
            uitext.DrawText("鍵がかかっている");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            GameManager.Instance.ExitDoorText = false;
            GM.PlayMode = GameManager.Mode.Play;
        }
        else if (GameManager.Instance.ExitDoorText == true && GameManager.Instance.ExitKeyGet == true)
        {
            uitext.DrawText("出口の鍵を使った");
            yield return StartCoroutine("Skip");

            uitext.DrawText("鍵が開いた");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            GameManager.Instance.ExitDoorText = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        //DogSelect dog = GameObject.Find("Text").GetComponent<DogSelect>();
        //if(dog.DogText == true) //犬に近づいたときのテキスト
        //{
        //    uitext.DrawText("犬がいる。……眠っているようだ");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    StartCoroutine(dog.Selection());
        //    dog.DogText = false;
        //}
        //if(dog.selectText1 == true) //そのまま通り過ぎるを選択
        //{
        //    uitext.DrawText("足音を立てないようにそっと近づいた");
        //    yield return StartCoroutine("Skip");
        //    uitext.DrawText("……！！");

        //    uitext.DrawText(" ");
        //    SceneManager.LoadScene("gameoverScene");
        //}
        //else if(dog.selectText2 == true) //何もしないを選択
        //{
        //    uitext.DrawText("下手に刺激しない方がいいだろう");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    GM.PlayMode = GameManager.Mode.Play;
        //    dog.selectText2 = false;
        //    dog.entrance = false;
        //    SceneManager.LoadScene("SampleScene");
        //}
        //else if(dog.selectText3 == true) //生肉を投げるを選択
        //{
        //    uitext.DrawText("主人公", "「よし……！これで外に出られる！」");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ", " ");
        //    SceneManager.LoadScene("gameclearScene");
        //}
    }  
}