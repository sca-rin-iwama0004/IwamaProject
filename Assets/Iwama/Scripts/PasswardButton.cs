using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PasswardButton : MonoBehaviour
{
    public string alphabet;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void OnClickThis()
    {
        transform.GetComponentInParent<PasswordPanel1>().buttonInput(alphabet);
    }
}
 
