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
    { //エンターを押したらで仮実装
        if (Input.GetKey(KeyCode.Return))
        {
            //ドアはドアを開くを押したらシーンが変わるように
            if (statue.GetComponent<StatueMove>().isLookingAtTarget)
            {
                SceneManager.LoadScene("RightroomScene");
            }
        }
      
    }
}
//StarueMoveにまとめたらいらないかも