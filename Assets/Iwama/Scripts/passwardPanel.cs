using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passwardPanel : MonoBehaviour
{
    
   int[] Answer = { 3, 0, 5, 4 };
   [SerializeField] NumberPanel[] numberPanels = default;
    
   

    public void OcCilickButton()
        {
            if (CheckClear())
            {
                Debug.Log("Clear");
            } 
        }

      bool CheckClear()
         {
            for(int i = 0; i < numberPanels.Length; i++)
            {
                 if (numberPanels[i].number != Answer[i])
                 {
                    return false;
                 }
            }
        return true;
    }
      
}
