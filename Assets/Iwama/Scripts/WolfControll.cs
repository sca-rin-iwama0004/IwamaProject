using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WolfControll : MonoBehaviour
{
   private Animator animator;//アニメーターコンポーネント取得
   public bool gameOver = false;
   public bool gameClear = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //KeyではなくUIでtextを表示させ、押して選択するように変更する
        if (Input.GetKey(KeyCode.Y))//肉をあげる
        {
            animator.SetBool("idle", false);
            animator.SetBool("getFood",true);
          
            Invoke("SceneChange", 3);
            gameClear = true;
        }
        if (Input.GetKey(KeyCode.N))//このまま出る
        {
            //攻撃する
            animator.SetBool("idle", false);
            animator.SetBool("getFood", false);
            gameOver = true;
            //カメラをアップにしたい 0.27 2.79 -3.03
            //20 0 0
            Invoke("SceneChange",3);
        }
    }

    void SceneChange()
    {
        if (gameOver)
            SceneManager.LoadScene("gameoverScene");
        else if(gameClear)
            SceneManager.LoadScene("gameclearScene");
    }
}
//カメラ通常　0、4.07、-3.73
//肉を投げる感じの動き
//肉の位置　0.39 0.60