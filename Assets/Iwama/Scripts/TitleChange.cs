using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleChange : MonoBehaviour
{
    public GameObject defaltTitle;//�f�t�H���g�̃^�C�g�����
    public GameObject happyTitle;//�n�b�s�[�G���h�̃^�C�g�����

    // Start is called before the first frame update
    void Start()
    {
       
       if (GameManager.Instance.HappyEnd || GameManager.Instance.GameClear)
      {
         happyTitle.SetActive(true);
         defaltTitle.SetActive(false);
       }
       else
      {
        happyTitle.SetActive(false);
        defaltTitle.SetActive(true);
      }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

   
}
