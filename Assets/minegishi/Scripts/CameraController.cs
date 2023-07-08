using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject playerObject;         //追尾 オブジェクト
    public Vector2 rotationSpeed;           //回転速度
    private Vector3 lastMousePosition;      //最後のマウス座標
    private Vector3 lastTargetPosition;     //最後の追尾オブジェクトの座標


    private float zoom;

    void Start()
    {
        zoom = 0.0f;
        lastMousePosition = Input.mousePosition;
        lastTargetPosition = playerObject.transform.position;
    }

    void Update()
    {
        Rotate();
    }


    void Rotate()
    {
        transform.position += playerObject.transform.position - lastTargetPosition;
        lastTargetPosition = playerObject.transform.position;

        if (Input.GetMouseButton(1))
        {

            Vector3 nowMouseValue = Input.mousePosition - lastMousePosition;

            var newAngle = Vector3.zero;
            newAngle.x = rotationSpeed.x * nowMouseValue.x;
            newAngle.y = rotationSpeed.y * nowMouseValue.y;

            transform.RotateAround(playerObject.transform.position, Vector3.up, newAngle.x);
            transform.RotateAround(playerObject.transform.position, transform.right, -newAngle.y);
        }

        lastMousePosition = Input.mousePosition;
    }
}