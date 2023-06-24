using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        BookShelf bookshelf = GameObject.Find("BookShelf").GetComponent<BookShelf>();
        if (bookshelf.gimmicktext)
        { //本棚のテキスト
            uitext.DrawText("本棚が動いた");
            yield return StartCoroutine("Skip");
            // Destroy();
            uitext.DrawText("扉が出てきた");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            bookshelf.gimmicktext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }


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
        if (exitkey.exitKeyText == true)
        {
            uitext.DrawText("出口の鍵を手に入れた");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            exitkey.exitKeyText = false;
            GM.PlayMode = GameManager.Mode.Play;
            Destroy(exitKey);
        }

        testDoor exitdoor = GameObject.Find("ExitDoor").GetComponent<testDoor>();
        if (exitdoor.opentext == true && ExitKey.exitKey == false)
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