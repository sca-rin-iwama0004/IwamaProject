using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockButton : MonoBehaviour
{
    public BoxUnlock bu;
    bool unlock = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockButtons()
    {
        if (GameManager.Instance.JuwelCount == 3 && !unlock)
        {
            Debug.Log("�����J��");
            bu.enabled = true;
            unlock = true;
        }
        //unrock�̓Q�[�}�l���H
    }

}
