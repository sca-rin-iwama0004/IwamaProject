using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextWriter : MonoBehaviour
{
    public UIText uitext;
    GameManager GM;


    private static bool created = false;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

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
        if(GM.GameStartText == true) //�Q�[���J�n���̃e�L�X�g
        {
            uitext.DrawText("�����͎�l���o�����Ă���炵��");
            yield return StartCoroutine("Skip");
            uitext.DrawText("��l���A���Ă���O�ɂ��̉��~���瓦���o�����I");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            GM.GameStartText = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        //if (prison.prisonkeytext == true) //�S���̌��̃e�L�X�g
        //{
        //    uitext.DrawText("�S���̌�����ɓ��ꂽ");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    prisonkeytext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //    Destroy(prisonkey);
        //}

        //if(prison.prisontext == true && prison.prisonkey == false) //�S���̃e�L�X�g
        //{
        //    uitext.DrawText("�����������Ă���");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    prisontext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}
        //else if(prison.prisontext == true && prison.prisonkey == true)
        //{
        //    uitext.DrawText("�S���̌����g����");
        //    yield return StartCoroutine("Skip");
        //    uitext.DrawText("�����J����");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    prisontext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}

        //if (meat.meattext == true) //���̃e�L�X�g
        //{
        //    uitext.DrawText("������ɓ��ꂽ");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    meattext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //    Destroy(meat);
        //}

        //if (rod.rodtext == true) //�_�̃e�L�X�g
        //{
        //    uitext.DrawText("�_����ɓ��ꂽ");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    rodtext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //    Destroy(rod);
        //}

        //if(juwel.juweltext == true) //��΂̃e�L�X�g
        //{
        //    uitext.DrawText("��΂���ɓ��ꂽ");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    juweltext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //    Destroy(juwel);
        //}

        //if(kinko.kinkotext == true && kinko.open == false) //�E�̕����̋��ɂ̃e�L�X�g
        //{
        //    uitext.DrawText("�����������Ă���");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    kinkotext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}
        //else if(kinko.kinkotext == true && kinko.open == true)
        //{
        //    uitext.DrawText("��΂��R�͂߂�");
        //    yield return StartCoroutine("Skip");
        //    uitext.DrawText("�����J����");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    kinkotext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}

        //if(safekey.keytext == true) //���ɂ̌��̃e�L�X�g
        //{
        //    uitext.DrawText("���ɂ̌�����ɓ��ꂽ");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    safekey.keytext =false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //    Destroy(safekey);
        //}

        BookShelf bookshelf = GameObject.Find("bookcase").GetComponent<BookShelf>();
        if (bookshelf.gimmicktext) //�{�I�̃e�L�X�g
        { 
            uitext.DrawText("�{�I��������");
            yield return StartCoroutine("Skip");
            uitext.DrawText("�����o�Ă���");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            bookshelf.gimmicktext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        //if(safe.safetext == true && safekey == false)
        //{
        //    uitext.DrawText("�����������Ă���");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    safe.safetext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}
        SafeGimmick safe = GameObject.Find("Safe").GetComponent<SafeGimmick>();
        if (safe.safetext == true) //���ɂ̃e�L�X�g
        {
            uitext.DrawText("���ɂ��J����");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            safe.safetext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        ExitKey exitkey = GameObject.Find("ExitKey").GetComponent<ExitKey>();
        GameObject exitKey = GameObject.Find("ExitKey");
        if (exitkey.exitKeyText == true) //�o���̌��̃e�L�X�g
        {
            uitext.DrawText("�o���̌�����ɓ��ꂽ");
            yield return StartCoroutine("Skip");

            uitext.DrawText("");
            exitkey.exitKeyText = false;
            GM.PlayMode = GameManager.Mode.Play;
            Destroy(exitKey);
        }

        ExitDoor exitdoor = GameObject.Find("ExitDoor").GetComponent<ExitDoor>();
        if (exitdoor.opentext == true && ExitKey.exitKey == false)�@//�o���̃e�L�X�g
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

        DogSelect dog = GameObject.Find("Text").GetComponent<DogSelect>();
        if(dog.DogText == true) //���ɋ߂Â����Ƃ��̃e�L�X�g
        {
            uitext.DrawText("��������B�c�c�����Ă���悤��");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            StartCoroutine(dog.Selection());
            dog.DogText = false;
        }
        if(dog.selectText1 == true) //���̂܂ܒʂ�߂����I��
        {
            uitext.DrawText("�����𗧂ĂȂ��悤�ɂ����Ƌ߂Â���");
            yield return StartCoroutine("Skip");
            uitext.DrawText("�c�c�I�I");

            uitext.DrawText(" ");
            SceneManager.LoadScene("gameoverScene");
        }
        else if(dog.selectText2 == true) //�������Ȃ���I��
        {
            uitext.DrawText("����Ɏh�����Ȃ������������낤");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            GM.PlayMode = GameManager.Mode.Play;
            dog.selectText2 = false;
            dog.entrance = false;
            SceneManager.LoadScene("SampleScene");
        }
        else if(dog.selectText3 == true) //�����𓊂����I��
        {
            uitext.DrawText("��l��", "�u�悵�c�c�I����ŊO�ɏo����I�v");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ", " ");
            SceneManager.LoadScene("gameclearScene");
        }
    }  
}