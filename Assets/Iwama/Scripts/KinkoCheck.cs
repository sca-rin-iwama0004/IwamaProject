using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinkoCheck : MonoBehaviour
{
    public GameObject keyKinko;
    public GameObject subCamera;
    bool keykaijo = false;

    void Update()
    {
            if (GameManager.Instance.JuwelCount == 3 && subCamera.activeInHierarchy && !keykaijo)
            {
            Debug.Log("�����J��");
            keyKinko.SetActive(true);
            keykaijo = true;
            }
    }
  }