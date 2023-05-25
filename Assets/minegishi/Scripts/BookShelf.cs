using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    private Vector3 pos;

    static bool gimmick = false;
    public bool gimmicktext = false;

    public TimerCounter timer;

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
        if(_state != _nextState) //ステートが切り替わったら
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
        if (Input.GetMouseButtonDown(0))
        {
            //clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.name == "BookShelf" && !gimmick) //本棚をクリック
                {
                    Debug.Log("gimmick");
                    ChangeState(StateType.Gimmick);
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
        if (pos.z > -1f)
        {
            transform.Translate(0,0,-0.002f);
        }
        else if(pos.z < -1f && pos.x < -22f)
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
        gimmick = true;
        gimmicktext = true;
        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
        StartCoroutine(text.Cotest());
        ChangeState(StateType.Play);
    }
}
