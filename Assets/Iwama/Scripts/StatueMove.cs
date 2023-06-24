using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatueMove : MonoBehaviour
{
    public Transform target;//視線の対象となるオブジェクト
    public float maxDistance = 10f;//視点を判定する最大距離
    public bool isLookingAtTarget = false;//フラグ

    bool Moveing = false;
    public AudioClip sound;
    AudioSource audioSource;

     //bool rightDoor = false;//このフラグはいらないかも？
    //privateを書いても書かなくてもいいのか

    //Unityでオブジェクトが見つめあったかどうかを検出したい
    //→視点の方向や距離を判定する必要がある

    void Start()
    {
        //右のドアのかぎが開いていたら
       if (GameManager.Instance.RightKey)
       {
            this.transform.Rotate(0,-90,0);
       }

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //銅像を動かす
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isLookingAtTarget && !GameManager.Instance.RightKey)
            {
               if (!Moveing)
               StartCoroutine("Rotate");
               Moveing = true;
            } 
        }

        //自分の位置からターゲットまでのベクトルを求める
        Vector3 direction = target.position - transform.position;

        //ターゲットまでの距離が最大距離以内であれば視点を判定する
        if (direction.magnitude <= maxDistance)
        {
            //自分の正面方向とターゲットへの方向の内積を計算
            float dot = Vector3.Dot(transform.forward, direction.normalized);

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

        if (Input.GetKey(KeyCode.Return))
        {
            //ドアはドアを開くを押したらシーンが変わるように
            if (isLookingAtTarget)
            {
                SceneManager.LoadScene("RightroomScene");
            }
        }
    }

    IEnumerator Rotate()
    {
        audioSource.PlayOneShot(sound);

        for (int turn = 0; turn < 90; turn++)
        {
            transform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.01f);
        }
        Moveing = false;


        //目と目が合っているか判定する
        if (isLookingAtTarget)
        {
           // Debug.Log("目が合っている");
            GameManager.Instance.RightKey = true;
           // Debug.Log(rightDoor);
          
        }
        else
        {
            //Debug.Log("目が合ってない");
            GameManager.Instance.RightKey = false;
            //  Debug.Log(rightDoor);
        }
    }

}



