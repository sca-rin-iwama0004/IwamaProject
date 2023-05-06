using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    private float startTime, distance;
    private Vector3 startPosition, targetPosition;

    enum STATE
    {
        WALK = 0,
        TEXT,
        GIMMICK,
    }

    void Start()
    {
        //スタート時間をキャッシュ
        startTime = Time.time;
        //スタート位置をキャッシュ
        startPosition = transform.position;
        //到着地点をセット
        targetPosition = new Vector3(0, 0, 10);
        //目的地までの距離を求める
        distance = Vector3.Distance(startPosition, targetPosition);

    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("クリック");
            //現在フレームの補間値を計算
            float interpolatedValue = (Time.time - startTime) / distance;
            //移動させる
            transform.position = Vector3.Lerp(startPosition, targetPosition, interpolatedValue);
        }
    }
}
