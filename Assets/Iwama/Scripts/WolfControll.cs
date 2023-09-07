using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class WolfControll : MonoBehaviour
{
   private Animator animator;//�A�j���[�^�[�R���|�[�l���g�擾
   public bool gameOver = false;

    [SerializeField] GameObject closeB;
    [SerializeField] GameObject Button;//�I�����{�^��
    [SerializeField] GameObject WolfCamera;
    [SerializeField] GameObject clearButton;
   // [SerializeField] GameObject badButton;
    [SerializeField] GameObject Meat;

    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        Button.SetActive(false);
        WolfCamera.SetActive(false);
        animator = GetComponent<Animator>();

        if (GameManager.Instance.MeatGet)
        {
           clearButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit = new RaycastHit();
            float maxRayDistance = 3f; // Ray����ԍő�̋���
            int mask = 1 << 6;//������ray��������Ȃ��悤��

            if (Physics.Raycast(ray, out hit, maxRayDistance, mask))
            {

                if (hit.collider.gameObject.name == "Wolf")
                {
                    
                    Button.SetActive(true);
                    WolfCamera.SetActive(true);
                }
            }

        }
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
        Button.SetActive(false);
        animator.SetBool("idle", false);
        //Meat.SetActive(true);
        Meat.transform.position = new Vector3(0.39f, 0.69f, -1.51f);
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
        Button.SetActive(false);
        //�U������
        animator.SetBool("idle", false);
        animator.SetBool("getFood", false);
        gameOver = true;
        //�J�������A�b�v�ɂ����� 0.27 2.79 -3.03
        //20 0 0
        Invoke("SceneChange", 3);
    }

    public void CloseButton()//����(�~)���������Ƃ�
    {
       Button.SetActive(false);
       WolfCamera.SetActive(false);
    }
}
//�J�����ʏ�@0�A4.07�A-3.73
//���̈ʒu�@0.39 0.60