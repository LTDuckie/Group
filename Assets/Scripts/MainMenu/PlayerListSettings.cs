using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridManager : MonoBehaviour
{
    public GameObject elementPrefab;  // 预制的 Element 模板
    public Transform gridParent;      // Grid Layout Group 的父物体
    public Sprite[] images;           // 图片数组（可在 Inspector 里拖入多张图片）,后续改成读取文件图片
    public string[] texts;            // 文字数组（Inspector 里编辑文本）

    void Start() //  运行时自动生成
    {
        GenerateElements();
    }

    public void GenerateElements()
    {
        // 先清空 Grid 内已有的元素，防止重复创建
        foreach (Transform child in gridParent)
        {
            Destroy(child.gameObject);
        }

        // 确保数据匹配
        int count = Mathf.Min(images.Length, texts.Length);

        for (int i = 0; i < count; i++)
        {
            // **克隆 Element 预制体**
            GameObject newElement = Instantiate(elementPrefab, gridParent);
            newElement.SetActive(true);

            // **修改 Image**
            Image elementImage = newElement.transform.Find("Image").GetComponent<Image>();
            if (elementImage != null)
            {
                elementImage.sprite = images[i];
            }
            else
                Debug.LogError("Element 的 Image 组件未找到！");

            // **修改 Text**
            TextMeshProUGUI elementText = newElement.GetComponentInChildren<TextMeshProUGUI>();
            if (elementText != null)
            {
                elementText.text = texts[i];
            }
            else
                Debug.LogError("Element 的 Text 组件未找到！");

            foreach (Behaviour component in newElement.GetComponentsInChildren<Behaviour>(true))
            {
                component.enabled = true;
            }
        }
    }
}