using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    public GameObject keyBox;
    public GameObject subCamera;
    bool Unlock = false;//�����J���������`�F�b�N

    void Update()
    {
            if (GameManager.Instance.JuwelCount == 3 && subCamera.activeInHierarchy && !Unlock)
            {
            Debug.Log("�����J��");
            keyBox.SetActive(true);
            Unlock = true;
            }
    }
  }