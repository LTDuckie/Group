using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridManager : MonoBehaviour
{
    public GameObject elementPrefab;  // Ԥ�Ƶ� Element ģ��
    public Transform gridParent;      // Grid Layout Group �ĸ�����
    public Sprite[] images;           // ͼƬ���飨���� Inspector ���������ͼƬ��,�����ĳɶ�ȡ�ļ�ͼƬ
    public string[] texts;            // �������飨Inspector ��༭�ı���

    void Start() //  ����ʱ�Զ�����
    {
        GenerateElements();
    }

    public void GenerateElements()
    {
        // ����� Grid �����е�Ԫ�أ���ֹ�ظ�����
        foreach (Transform child in gridParent)
        {
            Destroy(child.gameObject);
        }

        // ȷ������ƥ��
        int count = Mathf.Min(images.Length, texts.Length);

        for (int i = 0; i < count; i++)
        {
            // **��¡ Element Ԥ����**
            GameObject newElement = Instantiate(elementPrefab, gridParent);
            newElement.SetActive(true);

            // **�޸� Image**
            Image elementImage = newElement.transform.Find("Image").GetComponent<Image>();
            if (elementImage != null)
            {
                elementImage.sprite = images[i];
            }
            else
                Debug.LogError("Element �� Image ���δ�ҵ���");

            // **�޸� Text**
            TextMeshProUGUI elementText = newElement.GetComponentInChildren<TextMeshProUGUI>();
            if (elementText != null)
            {
                elementText.text = texts[i];
            }
            else
                Debug.LogError("Element �� Text ���δ�ҵ���");

            foreach (Behaviour component in newElement.GetComponentsInChildren<Behaviour>(true))
            {
                component.enabled = true;
            }
        }
    }
}