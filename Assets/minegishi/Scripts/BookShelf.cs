using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    [SerializeField] GameObject player;

    private Vector3 bookshelfpos;

    static bool gimmick = false;
    public bool gimmicktext = false;

    public TimerCounter timer;
    GameManager GM;

    private enum StateType
    {
        Play, //�ړ���
        Gimmick,//�M�~�b�N
    }
    private StateType _state = StateType.Play; //���݂̃X�e�[�g
    private StateType _nextState = StateType.Play; //���̃X�e�[�g


    void Start()
    {
        PlayStart();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        Transform myTransform = this.transform;
        bookshelfpos = myTransform.position; //�{�I�̍��W
        
        switch (_state)
        {
            case StateType.Play:
                PlayUpdate();
                break;
            case StateType.Gimmick:
                GimmickUpdate();
                break;
        }
        if (_state != _nextState) //�X�e�[�g���؂�ւ������
        {
            switch (_state)
            {
                case StateType.Play:
                    PlayEnd();
                    break;
                case StateType Gimmick:
                    GimmickEnd();
                    break;
            }

            _state = _nextState;
            switch (_state)
            {
                case StateType.Play:
                    PlayStart();
                    break;
                case StateType Gimmck:
                    GimmickStart();
                    break;
            }
        }

    }

    void ChangeState(StateType nextState)
    {
        _nextState = nextState;
    }


    void PlayStart()
    {
        Debug.Log("STOP");
    }
    void PlayUpdate()
    {
        Vector3 playerpos = player.transform.position;�@//player�̍��W        
        float dis = Vector3.Distance(bookshelfpos, playerpos);
        if (GM.PlayMode == GameManager.Mode.Play) { 
            if (Input.GetMouseButtonDown(0))
            {
                //clickedGameObject = null;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "BookShelf" && !gimmick && dis <= 9) //�{�I���N���b�N���M�~�b�N����x���쓮���Ă��Ȃ���
                    {
                        GM.PlayMode = GameManager.Mode.Gimmick;
                        Debug.Log("gimmick");
                        ChangeState(StateType.Gimmick);
                    }
                }
            }
        }
    }

    void PlayEnd()
    {

    }

    void GimmickStart()
    {

    }

    void GimmickUpdate()
    {
        //�{�I�ړ�
        if (bookshelfpos.z > -4f)
        {
            transform.Translate(0.002f, 0, 0);
        }

        else
        {

            GimmickEnd();
            // StartCoroutine(text.Cotest());
        }

    }
    public void GimmickEnd()
    {
        gimmick = true; //�M�~�b�N���쓮����
        gimmicktext = true; //�e�L�X�g�\��
        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
        GM.PlayMode = GameManager.Mode.Text;
        StartCoroutine(text.Cotest());
        ChangeState(StateType.Play);
    }
}
