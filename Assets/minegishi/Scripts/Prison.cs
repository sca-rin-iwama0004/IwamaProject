using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prison : MonoBehaviour
{
    [SerializeField] Transform rouya;
    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.RouyaKeyGet)
        {
            rouya.transform.position = new Vector3(-12, -10, -10);
        }
    }
}
