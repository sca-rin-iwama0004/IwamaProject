using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoroll : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject subCamera;

    // Start is called before the first frame update
    void Start()
    {
       mainCamera = GameObject.Find("MainCamera");
       subCamera = GameObject.Find("SubCamera");

       subCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))//詳しく見るボタン(カメラアップする)
        {
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
        }

        //カメラがアップの時(boolでもいい？)
        if (Input.GetKey(KeyCode.X)&& subCamera.activeInHierarchy)//×(戻る)ボタン
        {
            mainCamera.SetActive(true);
            subCamera.SetActive(false);
        }
    }
}
