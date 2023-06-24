using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{
    private float speed = 2f;
    private float maxAngle = 10f;

    float  startTime;
    Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
       // startTime = Time.time;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //タイトルのFの部分を左右に揺らす
        transform.rotation = startRotation * Quaternion.Euler(0f,0f,Mathf.Sin((Time.time) * speed) * maxAngle);
    }
}
/*https:// teratail.com/questions/313783*/
//Mathf.Sin((Time.time - startTime)としているのはこのスクリプトがアタッチされたオブジェクトが
//ゲームを開始してから途中で生成されてシーンに追加された時などに最初のSinの引数が0になるようにするため。
//途中からシーンに追加されても揺れ始めの回転値がQuaternion.Euler(0f,0f,0f)になることを意図。
//Mathf.Sin((Time.time)も可能

//Mathf.Sin((Time.time)→周期的な運動が作れる
//https:// qiita.com/Nekomasu/items/f526b9392fd16f2bd243