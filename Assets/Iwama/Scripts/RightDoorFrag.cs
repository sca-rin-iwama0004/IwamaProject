using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RightDoorFrag : MonoBehaviour
{
    public GameObject statue;

    // Start is called before the first frame update
    void Start()
    {
        statue = GameObject.Find("statue");
    }

    // Update is called once per frame
    void Update()
    { //�G���^�[����������ŉ�����
        if (Input.GetKey(KeyCode.Return))
        {
            //�h�A�̓h�A���J������������V�[�����ς��悤��
            if (statue.GetComponent<StatueMove>().isLookingAtTarget)
            {
                SceneManager.LoadScene("RightroomScene");
            }
        }
      
    }
}
//StarueMove�ɂ܂Ƃ߂��炢��Ȃ�����