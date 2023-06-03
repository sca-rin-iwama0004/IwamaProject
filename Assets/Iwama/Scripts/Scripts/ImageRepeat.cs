using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRepeat : MonoBehaviour
{
    public float stretchSpeed = 1.0f; // �L�k�̑��x
    public float minScale = 0.5f; // �ŏ��̃X�P�[��
    public float maxScale = 2.0f; // �ő�̃X�P�[��

    private float targetScale = 1.0f; // �ڕW�̃X�P�[��
    private float currentScale = 1.0f; // ���݂̃X�P�[��

    private void Start()
    {
        // �����̖ڕW�X�P�[����ݒ�
      //  targetScale = Random.Range(minScale, maxScale);
    }

    private void Update()
    {
        // �X�P�[�������X�ɕω�������
        currentScale = Mathf.Lerp(currentScale, targetScale, Time.deltaTime * stretchSpeed);
        transform.localScale = new Vector3(currentScale, transform.localScale.y, transform.localScale.z);

        // �ڕW�X�P�[���ɋ߂Â�����A�V�����ڕW�X�P�[���������_���ɐݒ�
        if (Mathf.Abs(currentScale - targetScale) < 0.01f)
        {
            targetScale = Random.Range(minScale, maxScale);
        }
    }
}
