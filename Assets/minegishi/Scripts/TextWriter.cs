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

        Debug.Log("Text");
        Meat meat = GameObject.Find("Meat").GetComponent<Meat>();
        if (meat.meatText == true) //���̃e�L�X�g
        {
            uitext.DrawText("������ɓ��ꂽ");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            meat.meatText = false;
            GM.PlayMode = GameManager.Mode.Play;
            //Destroy(meat);
            meat.transform.position = new Vector3(0, -5, 0); //��ʊO�Ɉړ�
        }

        Stick stick = GameObject.Find("Stick").GetComponent<Stick>();
        if (stick.stickText == true) //�_�̃e�L�X�g
        {
            uitext.DrawText("�_����ɓ��ꂽ");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            stick.stickText = false;
            GM.PlayMode = GameManager.Mode.Play;
            //Destroy(rod);
            stick.transform.position = new Vector3(-2.6f, -5, -2);�@//��ʊO�Ɉړ�
        }

        //if(juwel.juweltext == true) //��΂̃e�L�X�g
        //{
        //    uitext.DrawText("��΂���ɓ��ꂽ");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    juweltext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //    Destroy(juwel);
        //}

        //if(statue.statuetext == true) //�������Ȃ������̃e�L�X�g
        //{
        //    uitext.DrawText("�����A������̑��ƌ����������Ă���");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    statue.statuetext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}
        //if(statue.moveStatueText == true) //�������铺���̃e�L�X�g
        //{
        //    uitext.DrawText("�����A�c�c�悭����ƃ{�^�����t���Ă��ē�����������");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    statue.moveSatatueText = false;
        //}
        //if(statue.opentext == true) //��������������������
        //{
        //    uitext.DrawText("�߂��̕������J�����悤��");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    Statue.opentext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}

        //if(pot.pottext == true) //��̃e�L�X�g
        //{
        //    uitext.DrawText("�₾�B�ǂ��i���Ɍ�����B");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    pot.pottext = false;
        //    GM.PlayMode = GameManager.Mode.Play;
        //}

        ManualBook manual = GameObject.Find("ManualBook").GetComponent<ManualBook>();
        if (manual.manualtext == true) //�Ŏ�p�}�j���A���̃e�L�X�g
        {
            uitext.DrawText("�{�I�̒�����Ŏ�p�}�j���A���Ƃ����{���������B");
            yield return StartCoroutine("Skip");
            uitext.DrawText("�ǂ����Ŏ�̐ݒ�Ȃǂ������Ă���悤���B");
            yield return StartCoroutine("Skip");
            uitext.DrawText("�Ō�̃y�[�W�ɊŎ���~�߂邽�߂̃p�X���[�h�������Ă���B");
            yield return StartCoroutine("Skip");
            uitext.DrawText("3054�c�c�A�o���Ă������B");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            manual.manualtext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

        PasswordPanel1 pas = GameObject.Find("ImagePanel").GetComponent<PasswordPanel1>();
        if (pas.anstext == true && PasswordPanel1.ans == false) //�p�X���[�h���s�����̎�
        {
            uitext.DrawText("�c�c�����N���Ȃ�");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            pas.anstext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }
        if (pas.anstext == true && PasswordPanel1.ans == true) //�p�X���[�h�������̎�
        {
            uitext.DrawText("����ŊŎ�͎~�܂����͂���");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            pas.anstext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }

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

        SafeKey safekey = GameObject.Find("SafeKey").GetComponent<SafeKey>();
        if (safekey.safeKeyText == true) //���ɂ̌��̃e�L�X�g
        {
            uitext.DrawText("���ɂ̌�����ɓ��ꂽ");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            safekey.safeKeyText = false;
            GM.PlayMode = GameManager.Mode.Play;
            safekey.transform.position = new Vector3(10000, 10000, 10000);
        }

        //RobotMove robot = GameObject.Find("Robot").GetComponent<RobotMove>();
        if (GM.robotText) //���{�b�g�̃e�L�X�g
        {
            uitext.DrawText("�Ŏ�", "�E���҃n�b�P��");
            yield return StartCoroutine("Skip");
            uitext.DrawText(" ", "�Ŏ�Ɍ������Ă��܂����I");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            GM.robotText = false;
            GM.PlayMode = GameManager.Mode.end;
            SceneManager.LoadScene("gameoverScene");
        }

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

        Kanaria kanaria = GameObject.Find("kanaria").GetComponent<Kanaria>();
        if (kanaria.kanariaText)
        {
            uitext.DrawText("�J�i���A�������Ă���");
            yield return StartCoroutine("Skip");
            uitext.DrawText("�J�i���A��������");
            yield return StartCoroutine("Skip");
            uitext.DrawText("�J�i���A", "�u�����Ă���Ă��肪�Ƃ��I�v");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ", " ");
            kanaria.kanariaText = false;
            kanaria.transform.position = new Vector3(-16.75f, -10, 8);
            GM.PlayMode = GameManager.Mode.Play;
        }

        SafeGimmick safe = GameObject.Find("Safe").GetComponent<SafeGimmick>();
        if (safe.safetext == true && SafeKey.safeKey == false)
        {
            uitext.DrawText("�����������Ă���");
            yield return StartCoroutine("Skip");

            uitext.DrawText(" ");
            safe.safetext = false;
            GM.PlayMode = GameManager.Mode.Play;
        }
        else if (safe.safetext == true && SafeKey.safeKey == true) //���ɂ̃e�L�X�g
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
            //Destroy(exitKey);
            exitkey.transform.position = new Vector3(-29, -20.8f, 10.9f); //��ʊO�Ɉړ�
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

        //DogSelect dog = GameObject.Find("Text").GetComponent<DogSelect>();
        //if(dog.DogText == true) //���ɋ߂Â����Ƃ��̃e�L�X�g
        //{
        //    uitext.DrawText("��������B�c�c�����Ă���悤��");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    StartCoroutine(dog.Selection());
        //    dog.DogText = false;
        //}
        //if(dog.selectText1 == true) //���̂܂ܒʂ�߂����I��
        //{
        //    uitext.DrawText("�����𗧂ĂȂ��悤�ɂ����Ƌ߂Â���");
        //    yield return StartCoroutine("Skip");
        //    uitext.DrawText("�c�c�I�I");

        //    uitext.DrawText(" ");
        //    SceneManager.LoadScene("gameoverScene");
        //}
        //else if(dog.selectText2 == true) //�������Ȃ���I��
        //{
        //    uitext.DrawText("����Ɏh�����Ȃ������������낤");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ");
        //    GM.PlayMode = GameManager.Mode.Play;
        //    dog.selectText2 = false;
        //    dog.entrance = false;
        //    SceneManager.LoadScene("SampleScene");
        //}
        //else if(dog.selectText3 == true) //�����𓊂����I��
        //{
        //    uitext.DrawText("��l��", "�u�悵�c�c�I����ŊO�ɏo����I�v");
        //    yield return StartCoroutine("Skip");

        //    uitext.DrawText(" ", " ");
        //    SceneManager.LoadScene("gameclearScene");
        //}
    }  
}