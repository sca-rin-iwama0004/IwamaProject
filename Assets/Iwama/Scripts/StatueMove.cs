using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatueMove : MonoBehaviour
{
    public Transform MoveObj;
    public Transform target;//視線の対象となるオブジェクト
    public float maxDistance = 100f;//視点を判定する最大距離
    public bool isLookingAtTarget = false;//銅像同士の目が合っているか

    bool Moveing = false;
    public AudioClip sound;
    AudioSource audioSource;

    Ray ray;

    //Unityでオブジェクトが見つめあったかどうかを検出したい
    //→視点の方向や距離を判定する必要がある
    void Start()
    {
        //右のドアのかぎが開いていたら
       if (GameManager.Instance.RightKey)
       {
            MoveObj.transform.Rotate(0,-90,0);
       }

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //銅像を動かす
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            int mask = 1 << 6;//MoveButtonにしかrayが当たらないように

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                if (!isLookingAtTarget && !GameManager.Instance.RightKey)
                {
                    if (!Moveing)
                         StartCoroutine("Rotate");
                        Moveing = true;
                }
            }
        }

        DirectionCheck();

        UnlockCheck();
    }

    IEnumerator Rotate()
    {
        audioSource.PlayOneShot(sound);

        for (int turn = 0; turn < 90; turn++)
        {
            MoveObj.transform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.01f);
        }
        Moveing = false;
    }

    public void DirectionCheck()//銅像が向き合っているかの判定
    {
        //自分の位置からターゲットまでのベクトルを求める
        Vector3 direction = target.position - MoveObj.transform.position;

        //ターゲットまでの距離が最大距離以内であれば視点を判定する
        if (direction.magnitude <= maxDistance)
        {
            //自分の正面方向とターゲットへの方向の内積を計算
            float dot = Vector3.Dot(MoveObj.transform.forward, direction.normalized);

            //内積が１に近いほど視線が合っていると判断する
            if (dot >= 0.9f)
            {
                isLookingAtTarget = true;
            }
            else
            {
                isLookingAtTarget = false;
            }
        }
        else
        {
            isLookingAtTarget = false;
        }
    }

    public void UnlockCheck() //銅像が向き合っていたら鍵を解除
    {
        if (isLookingAtTarget)
        {
            GameManager.Instance.RightKey = true;
        }
        else
        {
            GameManager.Instance.RightKey = false;
        }
    }
}