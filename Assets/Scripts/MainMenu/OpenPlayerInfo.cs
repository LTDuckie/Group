using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OpenPlayerInfo : MonoBehaviour
{
    public GameObject summonerID; // �洢 Summoner_ID ������
    public Transform SummonedList;
    public GameObject element;
    private Sprite[] images;
    
    void Start()
    {
        images = Resources.LoadAll<Sprite>("Images/Generated/Characters/Pixeled");
    }

    public void setPlayerInfo()
    {
        // ��ȡ��ǰ����İ�ť
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

        if (summonerID == null)
        {
            Debug.LogError("Summoner_ID Ϊ null��");
        }
        else if (clickedButton == null)
        {
            Debug.LogError("clickedButton Ϊ null��");
        }

        // ȷ�� Summoner_ID �� clickedButton ����Ϊ��
        
        if (summonerID != null && clickedButton != null)
        {
            // ���� Summoner_ID ��ͼƬ
            Image summonerImage = summonerID.transform.Find("Image").GetComponent<Image>();
            Image clickedImage = clickedButton.transform.Find("Image").GetComponent<Image>();

            if (summonerImage != null && clickedImage != null)
            {
                summonerImage.sprite = clickedImage.sprite;
            }
            else
            {
                Debug.LogError("δ�ҵ� Image �����");
            }

            // ���� Summoner_ID ���ı�
            TextMeshProUGUI summonerText = summonerID.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI clickedText = clickedButton.GetComponentInChildren<TextMeshProUGUI>();

            if (summonerText != null && clickedText != null)
            {
                summonerText.text = clickedText.text;
            }
            else
            {
                Debug.LogError("δ�ҵ� TextMeshProUGUI �����");
            }

            //�����������ɵ�ͼƬ
            element.SetActive(false);
            foreach (Transform child in SummonedList)
            {
                if (child.gameObject.name != "Img_element")
                {
                    // ������ǣ����ٸ�������
                    Destroy(child.gameObject);
                }
            }

            int count = images.Length;
            for (int i = 0; i < count; i++)
            {
                GameObject newImage = Instantiate(element, SummonedList);
                Image elementImage = newImage.transform.Find("Image").GetComponent<Image>();
                if (elementImage != null)
                {
                    elementImage.sprite = images[i];
                    newImage.SetActive(true);
                }
                else
                    Debug.LogError("Element �� Image ���δ�ҵ���");
            }
        }

    }
}
