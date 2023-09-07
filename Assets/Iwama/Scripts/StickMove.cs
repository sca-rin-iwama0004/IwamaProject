using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StickMove : MonoBehaviour
{


    private bool isDragging = false; // オブジェクトがドラッグ中かどうかのフラグ
    private Vector3 offset; // マウスクリック位置とオブジェクト位置のオフセット
    //[SerializeField] GameObject key;
    [SerializeField] GameObject Portao;
    [SerializeField] GameObject collision;//当たり判定の箱
    [SerializeField] GameObject stick;

    public Camera specificCamera;

    void OnMouseDown()
    {
        // マウスボタンが押されたときに呼ばれるイベント
        // オブジェクトの現在位置とマウスクリック位置の差分をオフセットに保存
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true; // ドラッグフラグを有効にする
    }

    void OnMouseUp()
    {
        // マウスボタンが離されたときに呼ばれるイベント
        isDragging = false; // ドラッグフラグを無効にする
    }

    void Update()
    {
        if (isDragging)
        {
            // ドラッグ中の処理
            // マウスの現在位置にオフセットを加えて新しい位置を計算し、オブジェクトの位置を更新
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = newPosition;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        // マウスのスクリーン座標をワールド座標に変換
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = specificCamera.transform.position.z;
        return specificCamera.ScreenToWorldPoint(mousePosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            Debug.Log("鍵を入手");
            //key.SetActive(false);
            Portao.SetActive(false);
            collision.SetActive(false);
            stick.SetActive(false);
            GameManager.Instance.RouyaKeyGet = true;
            GameManager.Instance.RouyaKeyText = true;
            Debug.Log(GameManager.Instance.RouyaKeyGet);
        }
    }
}