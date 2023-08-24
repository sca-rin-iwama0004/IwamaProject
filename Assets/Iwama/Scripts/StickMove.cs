using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StickMove : MonoBehaviour
{
    private bool isDragging = false; // オブジェクトがドラッグ中かどうかのフラグ
    private Vector3 offset; // マウスクリック位置とオブジェクト位置のオフセット
    [SerializeField] GameObject key;
    [SerializeField] GameObject Portao;

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
        mousePosition.z = Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            Debug.Log("鍵を入手");
            key.SetActive(false);
            Portao.SetActive(false);
            GameManager.Instance.GreathellKey = true;
            Debug.Log(GameManager.Instance.GreathellKey);
        }
    }
}