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
       // Debug.Log(GameManager.Instance.HappyEnd);
       // if (GameManager.Instance.HappyEnd)
      //  {
         //  happyTitle.SetActive(true);
      //     defaltTitle.SetActive(false);
       // }
      ///  {
         //   happyTitle.SetActive(false);
            defaltTitle.SetActive(true);
       // }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

   
}
