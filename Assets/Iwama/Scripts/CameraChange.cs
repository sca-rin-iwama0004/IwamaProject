using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraChange : MonoBehaviour
{
    //���킹�ꂽ��CameraContoroll�ō��킹�������ǁA�T�u�J����2�g������������
    public GameObject mainCamera;
    public GameObject subCamera;
    private Camera subC;//�T�u�J����

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
        //�������H
        if (subC.fieldOfView > 18.90)
        {
            subC.fieldOfView--;
            yield return new WaitForSeconds(0.03f);
        }
    }

    /*
      void SceneChange()
     {
         SceneManager.LoadScene("gameoverScene");
     }
     */
}