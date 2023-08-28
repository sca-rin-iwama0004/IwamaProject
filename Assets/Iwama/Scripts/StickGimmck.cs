using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickGimmck : MonoBehaviour
{
    [SerializeField] GameObject mainC;
    [SerializeField] GameObject prisonC;//òSâÆÇÃÉJÉÅÉâ
    [SerializeField] GameObject closeB;//ï¬Ç∂ÇÈ(Å~)É{É^Éì
    [SerializeField] GameObject stick;//ìÆÇ©Ç∑é}
    float stickPosZ;                     
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        closeB.SetActive(false);
        prisonC.SetActive(false);
        stick.SetActive(false);
        stickPosZ = stick.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //ray = specificCamera.ScreenPointToRay(Input.mousePosition);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            int potMask = 1 << 7;//òSâÆÇ…êGÇÍÇΩÇ∆Ç´
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, potMask))
            {
                mainC.SetActive(false);
                prisonC.SetActive(true);
                closeB.SetActive(true);

                if (GameManager.Instance.StickGet)
                {
                    stick.SetActive(true);
                }
            }
        }
}

    public void CloseButton()//ï¬Ç∂ÇÈ(Å~)ÇâüÇµÇΩÇ∆Ç´
    {
        closeB.SetActive(false);
        mainC.SetActive(true);
        prisonC.SetActive(false);
    }
}