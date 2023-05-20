using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    public UIText uitext;
    public BookShelf bookshelf;
 
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "BookShelf") //�{�I���N���b�N
                {
                    //StartCoroutine("Contest");
                }
            }
        }
    }
    // �N���b�N�҂��̃R���[�`��
    public IEnumerator Skip()
    {
        while (uitext.playing) yield return 0;
        while (!uitext.IsClicked()) yield return 0;
    }

    // ���͂�\��������R���[�`��
    public IEnumerator Cotest()
    {
        
        uitext.DrawText("�{�I��������");
        yield return StartCoroutine("Skip");

        uitext.DrawText("�����o�Ă���");
        yield return StartCoroutine("Skip");

        uitext.DrawText("");

    }
}