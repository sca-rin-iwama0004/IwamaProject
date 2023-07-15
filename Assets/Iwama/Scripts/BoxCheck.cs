using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    public GameObject keyBox;
    public GameObject subCamera;
    bool Unlock = false;//鍵が開いたかをチェック

    void Update()
    {
            if (GameManager.Instance.JuwelCount == 3 && subCamera.activeInHierarchy && !Unlock)
            {
            Debug.Log("鍵が開く");
            keyBox.SetActive(true);
            Unlock = true;
            }
    }
  }