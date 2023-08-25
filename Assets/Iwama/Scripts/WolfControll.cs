using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class WolfControll : MonoBehaviour
{
   private Animator animator;//アニメーターコンポーネント取得
   public bool gameOver = false;

    [SerializeField] GameObject clearButton;
    [SerializeField] GameObject badButton;
    [SerializeField] GameObject Meat;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (GameManager.Instance.MeatGet)
        {
           clearButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SceneChange()
    {
        if (gameOver)
            SceneManager.LoadScene("gameoverScene");
        else if (GameManager.Instance.HappyEnd)
            SceneManager.LoadScene("HappyEndScene");
        else if(GameManager.Instance.GameClear)
            SceneManager.LoadScene("gameclearScene");
    }

    public void MeetButton()
    {

        animator.SetBool("idle", false);
        Meat.SetActive(true);
        animator.SetBool("getFood", true);

        if (GameManager.Instance.KanariaRescue)
        {
            GameManager.Instance.HappyEnd = true;
        }
        else
        {
            GameManager.Instance.GameClear = true;
        }

        Invoke("SceneChange", 4);
       
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