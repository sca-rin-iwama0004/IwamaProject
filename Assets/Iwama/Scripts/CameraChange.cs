using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraChange : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject subCamera;
    private Camera subC;//ÉTÉuÉJÉÅÉâ

    public WolfControll wc;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("MainCamera");
        subCamera = GameObject.Find("SubCamera");
        subC = GetComponent<Camera>();
        subCamera.GetComponent<Camera>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (wc.gameOver)
        {
            StartCoroutine("Zoom");
            mainCamera.GetComponent<Camera>().enabled = false;
            subCamera.GetComponent<Camera>().enabled = true;
        }
    }

    IEnumerator Zoom()
    {
        if (subC.fieldOfView > 18.00)
        {
            subC.fieldOfView-=3;
            yield return new WaitForSeconds(0.003f);
        }
    }
}