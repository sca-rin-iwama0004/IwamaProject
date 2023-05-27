﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public Vector2 rotationSpeed = new Vector2(0.1f,0.1f);

    private Vector2 lastMousePosition;
    private Vector2 newAnle = Vector2.zero;

    GameManager GM;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(GM.PlayMode == GameManager.Mode.Play) { 
            if(Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * moveSpeed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * moveSpeed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * moveSpeed * Time.deltaTime;
            }
        }

    }
}
