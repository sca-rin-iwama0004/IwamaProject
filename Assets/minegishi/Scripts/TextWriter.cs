using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    public UIText uitext;
    public BookShelf bookshelf;
 
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "BookShelf") //本棚をクリック
                {
                    //StartCoroutine("Contest");
                }
            }
        }
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
        
        uitext.DrawText("本棚が動いた");
        yield return StartCoroutine("Skip");

        uitext.DrawText("扉が出てきた");
        yield return StartCoroutine("Skip");

        uitext.DrawText("");

    }
}