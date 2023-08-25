using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PasswordPanel1 : MonoBehaviour
{
    GameManager GM;
    TextWriter text;

    public bool anstext = false;
    public static bool ans = false;

    // �A���t�@�x�b�g�̓��͂�����z��
    [SerializeField] string[] input;
    // �����̃A���t�@�x�b�g������z��
    [SerializeField] string[] collect;
    // ����input�̓Y��
    int index;
    // �������ɔ���������C�x���g
    public UnityEvent someEvent;
    // input�̓��e��\�����邽�߂̃e�L�X�g�BTextMeshPro�𗘗p�B
    [SerializeField] TMP_Text displayText;


    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        //text = GameObject.Find("Text").GetComponent<TextWriter>();
        //�J�n���ɏ�����������
        resetInput();
    }

    public void buttonInput(string alphabet)
    {
        //���͎��_�łS�������͂���Ă����珉��������B
        if (index == 4)
        {
            resetInput();
        }

        //���͂��ꂽ�A���t�@�x�b�g��ۑ����A�\���p�e�L�X�g�ɂ��ǉ�����
        input[index] = alphabet;
        displayText.text += alphabet;

        index++;

    }

    public void resetInput()
    {
        //�\���p�e�L�X�g��input�z�����(null)�ɂ���
        displayText.text = null;
        index = 0;
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = null;
        }
    }

    public void isClear()
    {
        // OK�{�^���������ꂽ���̏���
        // �����`�F�b�N���s���C�x���g�𔭐�������
        if (checkPassword())
        {
            ans = true;
            Debug.Log("OK");
         //   someEvent.Invoke();
        }

        GM.PlayMode = GameManager.Mode.Text;
        text = GameObject.Find("Text").GetComponent<TextWriter>();
        anstext = true;
        StartCoroutine(text.Cotest());
        resetInput();
    }

    public bool checkPassword()
    {
        // �P���������ԂɃ`�F�b�N���P�ł��ԈႢ�������False��Ԃ��B
        for (int i = 0; i < collect.Length; i++)
        {
            if (input[i] != collect[i])
            {
                return false;
            }
        }

        return true;
    }
}
//�J�����̈ʒu�Ƃ���ς�����L�����p�X�̈ʒu�Ƃ�������
//�X�N���v�g���̂͊����A����
//OK���������̏���(�@�B���~�߂�)
//�����o��