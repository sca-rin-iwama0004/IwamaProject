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
        Play, //移動中
        Gimmick,//ギミック
    }
    private StateType _state = StateType.Play; //現在のステート
    private StateType _nextState = StateType.Play; //次のステート


    void Start()
    {
        PlayStart();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        Transform myTransform = this.transform;
        bookshelfpos = myTransform.position; //本棚の座標
        
        switch (_state)
        {
            case StateType.Play:
                PlayUpdate();
                break;
            case StateType.Gimmick:
                GimmickUpdate();
                break;
        }
        if (_state != _nextState) //ステートが切り替わったら
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
        Vector3 playerpos = player.transform.position;　//playerの座標        
        float dis = Vector3.Distance(bookshelfpos, playerpos);
        if (GM.PlayMode == GameManager.Mode.Play) { 
            if (Input.GetMouseButtonDown(0))
            {
                //clickedGameObject = null;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "BookShelf" && !gimmick && dis <= 9) //本棚をクリック＆ギミックが一度も作動していない時
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
        //本棚移動
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
        gimmick = true; //ギミックが作動した
        gimmicktext = true; //テキスト表示
        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
        GM.PlayMode = GameManager.Mode.Text;
        StartCoroutine(text.Cotest());
        ChangeState(StateType.Play);
    }
}
