using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    public UIText uitext;
    GameManager GM;
    BookShelf bookshelf;
    SafeGimmick safe;
    ExitKey exitkey;
    ExitDoor exitdoor;

    private static bool created = false;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        bookshelf = GameObject.Find("BookShelf").GetComponent<BookShelf>();
        safe = GameObject.Find("Safe").GetComponent<SafeGimmick>();
        exitkey = GameObject.Find("ExitKey").GetComponent<ExitKey>();
        exitdoor = GameObject.Find("ExitDoor").GetComponent<ExitDoor>();

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
        if (safe.safetext == true) //金庫のテキスト
        {
            uitext.DrawText("金庫が開いた");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            safe.safetext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

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
    }  
}