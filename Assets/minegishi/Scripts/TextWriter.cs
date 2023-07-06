using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    public UIText uitext;
    GameManager GM;
    BookShelf bookshelf;
    SafeGimmick safe;
    ExitKey exitkey;
    ExitDoor exitdoor;

    private static bool created = false;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        bookshelf = GameObject.Find("BookShelf").GetComponent<BookShelf>();
        safe = GameObject.Find("Safe").GetComponent<SafeGimmick>();
        exitkey = GameObject.Find("ExitKey").GetComponent<ExitKey>();
        exitdoor = GameObject.Find("ExitDoor").GetComponent<ExitDoor>();

        if (!created)
        {
            created = true;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this.gameObject);
    }

    private void Update()
    {
        
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
        if (bookshelf.gimmicktext)
        { //�{�I�̃e�L�X�g
            uitext.DrawText("�{�I��������");
            yield return StartCoroutine("Skip");
            uitext.DrawText("�����o�Ă���");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            bookshelf.gimmicktext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        if (safe.safetext == true) //���ɂ̃e�L�X�g
        {
            uitext.DrawText("���ɂ��J����");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            safe.safetext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        GameObject exitKey = GameObject.Find("ExitKey");
        if (exitkey.exitKeyText == true)
        {
            uitext.DrawText("�o���̌�����ɓ��ꂽ");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            exitkey.exitKeyText = false;
            GM.PlayMode = GameManager.Mode.Play;
            Destroy(exitKey);
        }

        
        if (exitdoor.opentext == true && ExitKey.exitKey == false)
        {
            uitext.DrawText("�����������Ă���");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            exitdoor.opentext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }
        else if (exitdoor.opentext == true && ExitKey.exitKey == true)
        {
            uitext.DrawText("�o���̌����g����");
            yield return StartCoroutine("Skip");

            uitext.DrawText("�����J����");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            exitdoor.opentext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }
        /*if(){
         * uitext.DrawText("")
         * }
         */
    }  
}