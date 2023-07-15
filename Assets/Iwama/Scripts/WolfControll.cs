using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WolfControll : MonoBehaviour
{
   private Animator animator;//�A�j���[�^�[�R���|�[�l���g�擾
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
        //�U������
        animator.SetBool("idle", false);
        animator.SetBool("getFood", false);
        gameOver = true;
        //�J�������A�b�v�ɂ����� 0.27 2.79 -3.03
        //20 0 0
        Invoke("SceneChange", 3);
    }
}
//�J�����ʏ�@0�A4.07�A-3.73
//���𓊂��銴���̓���
//���̈ʒu�@0.39 0.60