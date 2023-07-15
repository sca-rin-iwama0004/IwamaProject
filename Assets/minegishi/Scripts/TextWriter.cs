using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextWriter : MonoBehaviour
{
    public UIText uitext;
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

        //if (meat.meattext == true) //肉のテキスト
        //{
        //    uitext.DrawText("肉を手に入れた");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    meattext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //    Destroy(meat);
        //}

        //if (rod.rodtext == true) //棒のテキスト
        //{
        //    uitext.DrawText("棒を手に入れた");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    rodtext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //    Destroy(rod);
        //}

        //if(juwel.juweltext == true) //宝石のテキスト
        //{
        //    uitext.DrawText("宝石を手に入れた");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    juweltext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //    Destroy(juwel);
        //}

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

        //if(safekey.keytext == true) //金庫の鍵のテキスト
        //{
        //    uitext.DrawText("金庫の鍵を手に入れた");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    safekey.keytext =false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //    Destroy(safekey);
        //}

        BookShelf bookshelf = GameObject.Find("bookcase").GetComponent<BookShelf>();
        if (bookshelf.gimmicktext) //本棚のテキスト
        { 
            uitext.DrawText("本棚が動いた");
            yield return StartCoroutine("Skip");
            uitext.DrawText("扉が出てきた");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            bookshelf.gimmicktext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        //if(safe.safetext == true && safekey == false)
        //{
        //    uitext.DrawText("鍵がかかっている");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    safe.safetext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}
        SafeGimmick safe = GameObject.Find("Safe").GetComponent<SafeGimmick>();
        if (safe.safetext == true) //金庫のテキスト
        {
            uitext.DrawText("金庫が開いた");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            safe.safetext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        ExitKey exitkey = GameObject.Find("ExitKey").GetComponent<ExitKey>();
        GameObject exitKey = GameObject.Find("ExitKey");
        if (exitkey.exitKeyText == true) //出口の鍵のテキスト
        {
            uitext.DrawText("出口の鍵を手に入れた");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            exitkey.exitKeyText = false;
            GM.PlayMode = GameManager.Mode.Play;
            Destroy(exitKey);
        }

        ExitDoor exitdoor = GameObject.Find("ExitDoor").GetComponent<ExitDoor>();
        if (exitdoor.opentext == true && ExitKey.exitKey == false)　//出口のテキスト
        {
            uitext.DrawText("鍵がかかっている");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            exitdoor.opentext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }
        else if (exitdoor.opentext == true && ExitKey.exitKey == true)
        {
            uitext.DrawText("出口の鍵を使った");
            yield return StartCoroutine("Skip");

            uitext.DrawText("鍵が開いた");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            exitdoor.opentext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        DogSelect dog = GameObject.Find("Text").GetComponent<DogSelect>();
        if(dog.DogText == true) //犬に近づいたときのテキスト
        {
            uitext.DrawText("犬がいる。……眠っているようだ");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            StartCoroutine(dog.Selection());
            dog.DogText = false;
        }
        if(dog.selectText1 == true) //そのまま通り過ぎるを選択
        {
            uitext.DrawText("足音を立てないようにそっと近づいた");
            yield return StartCoroutine("Skip");
            uitext.DrawText("……！！");

            uitext.DrawText(" ");
            SceneManager.LoadScene("gameoverScene");
        }
        else if(dog.selectText2 == true) //何もしないを選択
        {
            uitext.DrawText("下手に刺激しない方がいいだろう");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            GM.PlayMode = GameManager.Mode.Play;
            dog.selectText2 = false;
            dog.entrance = false;
            SceneManager.LoadScene("SampleScene");
        }
        else if(dog.selectText3 == true) //生肉を投げるを選択
        {
            uitext.DrawText("主人公", "「よし……！これで外に出られる！」");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ", " ");
            SceneManager.LoadScene("gameclearScene");
        }
    }  
}