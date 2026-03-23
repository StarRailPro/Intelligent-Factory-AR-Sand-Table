using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScaler : MonoBehaviour
{
    public Image targetImage; // 目标Image组件
    private RectTransform originalRectTransform; // 保存原始的RectTransform
    private bool isEnlarged = false; // 标记图片是否已放大
    void Start()
    {
        if (targetImage == null)

        {
            targetImage = GetComponent<Image>();
        }
        if (targetImage != null)
        {
            originalRectTransform = (RectTransform)targetImage.transform;
            // 添加点击事件监听器
            targetImage.GetComponent<RectTransform>().GetComponent<Button>().onClick.AddListener(OnImageClicked);
        }
        else
        {
            Debug.LogError("Target Image is not assigned or not found!");
        }
    }
    void OnImageClicked()
    {
        if (isEnlarged)
        {
            // 恢复到原始大小和位置
            originalRectTransform.localPosition = new Vector2(0, -350);
            originalRectTransform.localScale = Vector3.one;
            originalRectTransform.SetAsFirstSibling(); // 确保它在层级中处于最下层（可选，如果需要的话）
        }
        else
        {
            // 放大图片并设置到最上层
            originalRectTransform.localPosition = Vector3.up;
            originalRectTransform.localScale = new Vector3(1.5f, 1.5f, 1.5f); // 调整缩放比例
            originalRectTransform.SetAsLastSibling(); // 确保它在层级中处于最上层
        }
        isEnlarged = !isEnlarged; // 切换状态
    }
}
