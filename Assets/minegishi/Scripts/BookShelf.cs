using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    private Vector3 pos;

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
        pos = transform.position;

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
        if(GM.PlayMode == GameManager.Mode.Play) { 
            if (Input.GetMouseButtonDown(0))
            {
                //clickedGameObject = null;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == "BookShelf" && !gimmick) //本棚をクリック＆ギミックが一度も作動していない時
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
        if (pos.z > -1f)
        {
            transform.Translate(0, 0, -0.002f);
        }
        else if (pos.z < -1f && pos.x < -22f)
        {
            transform.Translate(0.005f, 0, 0);
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
