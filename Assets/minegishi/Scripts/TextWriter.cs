using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    public UIText uitext;
 
    void Start()
    {
        
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
        if (bookshelf.gimmicktext) { 
            uitext.DrawText("本棚が動いた");
            yield return StartCoroutine("Skip");

            uitext.DrawText("扉が出てきた");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            bookshelf.gimmicktext = false;
        }

        SafeGimmick safe = GameObject.Find("Safe").GetComponent<SafeGimmick>();
        if (safe.safetext == true)
        {
            uitext.DrawText("金庫が開いた");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            safe.safetext = false;
        }
    }
}