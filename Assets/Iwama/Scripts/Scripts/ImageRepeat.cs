using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRepeat : MonoBehaviour
{
    public float stretchSpeed = 1.0f; // 伸縮の速度
    public float minScale = 0.5f; // 最小のスケール
    public float maxScale = 2.0f; // 最大のスケール

    private float targetScale = 1.0f; // 目標のスケール
    private float currentScale = 1.0f; // 現在のスケール

    private void Start()
    {
        // 初期の目標スケールを設定
      //  targetScale = Random.Range(minScale, maxScale);
    }

    private void Update()
    {
        // スケールを徐々に変化させる
        currentScale = Mathf.Lerp(currentScale, targetScale, Time.deltaTime * stretchSpeed);
        transform.localScale = new Vector3(currentScale, transform.localScale.y, transform.localScale.z);

        // 目標スケールに近づいたら、新しい目標スケールをランダムに設定
        if (Mathf.Abs(currentScale - targetScale) < 0.01f)
        {
            targetScale = Random.Range(minScale, maxScale);
        }
    }
}
