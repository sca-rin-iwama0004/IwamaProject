using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberPanel : MonoBehaviour
{
    [SerializeField]  TMP_Text numText;
    public int number = 0;

    public void OcClick()
    {
        number++;
        if(number >= 10)
        {
            number = 0;
        }
        numText.text = number.ToString();
    }
    
}

