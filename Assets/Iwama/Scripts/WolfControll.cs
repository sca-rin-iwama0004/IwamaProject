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

    }

    void SceneChange()
    {
        if (gameOver)
            SceneManager.LoadScene("gameoverScene");
        else if(gameClear)
            SceneManager.LoadScene("gameclearScene");
    }

    public void MeetButton()
    {

        animator.SetBool("idle", false);
        animator.SetBool("getFood", true);

        Invoke("SceneChange", 3);
        gameClear = true;
    }

    public void NoMeetButton()
    {
        //攻撃する
        animator.SetBool("idle", false);
        animator.SetBool("getFood", false);
        gameOver = true;
        //カメラをアップにしたい 0.27 2.79 -3.03
        //20 0 0
        Invoke("SceneChange", 3);
    }
}
//カメラ通常　0、4.07、-3.73
//肉を投げる感じの動き
//肉の位置　0.39 0.60