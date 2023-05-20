using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    private Vector3 pos;

    static bool gimmick = false;
    

    private enum StateType
    {
        Stop, //�ړ�
        Gimmick,//�M�~�b�N
    }
    private StateType _state = StateType.Stop; //���݂̃X�e�[�g
    private StateType _nextState = StateType.Stop; //���̃X�e�[�g


    void Start()
    {
        StopStart();
    }

    void Update()
    {
        pos = transform.position;

        switch (_state)
        {
            case StateType.Stop:
                StopUpdate();
                break;
            case StateType.Gimmick:
                GimmickUpdate();
                break;
        }
        if(_state != _nextState) //�X�e�[�g���؂�ւ������
        {
            switch (_state)
            {
                case StateType.Stop:
                    StopEnd();
                    break;
                case StateType Gimmick:
                    GimmickEnd();
                    break;
            }

            _state = _nextState;
            switch (_state)
            {
                case StateType.Stop:
                    StopStart();
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
    

    void StopStart()
    {
        Debug.Log("STOP");
    }
    void StopUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.name == "BookShelf" && !gimmick) //�{�I���N���b�N
                {
                    Debug.Log("�N���b�N");
                    ChangeState(StateType.Gimmick);
                }
            }
        }
    }

    void StopEnd()
    {

    }

    void GimmickStart()
    {

    }

    void GimmickUpdate()
    {
        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
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
    public bool GimmickEnd()
    {
        gimmick = true;
        TextWriter text = GameObject.Find("Text").GetComponent<TextWriter>();
        StartCoroutine(text.Cotest());
        ChangeState(StateType.Stop);
        return true;
    }
}
