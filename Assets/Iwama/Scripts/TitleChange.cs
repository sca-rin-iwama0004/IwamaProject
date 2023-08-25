using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleChange : MonoBehaviour
{
    public GameObject defaltTitle;//デフォルトのタイトル画面
    public GameObject happyTitle;//ハッピーエンドのタイトル画面

    // Start is called before the first frame update
    void Start()
    {
       
       if (GameManager.Instance.HappyEnd || GameManager.Instance.GameClear)
      {
         happyTitle.SetActive(true);
         defaltTitle.SetActive(false);
       }
       else
      {
        happyTitle.SetActive(false);
        defaltTitle.SetActive(true);
      }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

   
}
