using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OpenPlayerInfo : MonoBehaviour
{
    public GameObject summonerID; // 存储 Summoner_ID 的引用
    public Transform SummonedList;
    public GameObject element;
    private Sprite[] images;
    
    void Start()
    {
        images = Resources.LoadAll<Sprite>("Images/Generated/Characters/Pixeled");
    }

    public void setPlayerInfo()
    {
        // 获取当前点击的按钮
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

        if (summonerID == null)
        {
            Debug.LogError("Summoner_ID 为 null！");
        }
        else if (clickedButton == null)
        {
            Debug.LogError("clickedButton 为 null！");
        }

        // 确保 Summoner_ID 和 clickedButton 都不为空
        
        if (summonerID != null && clickedButton != null)
        {
            // 设置 Summoner_ID 的图片
            Image summonerImage = summonerID.transform.Find("Image").GetComponent<Image>();
            Image clickedImage = clickedButton.transform.Find("Image").GetComponent<Image>();

            if (summonerImage != null && clickedImage != null)
            {
                summonerImage.sprite = clickedImage.sprite;
            }
            else
            {
                Debug.LogError("未找到 Image 组件！");
            }

            // 设置 Summoner_ID 的文本
            TextMeshProUGUI summonerText = summonerID.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI clickedText = clickedButton.GetComponentInChildren<TextMeshProUGUI>();

            if (summonerText != null && clickedText != null)
            {
                summonerText.text = clickedText.text;
            }
            else
            {
                Debug.LogError("未找到 TextMeshProUGUI 组件！");
            }

            //批量复制生成的图片
            element.SetActive(false);
            foreach (Transform child in SummonedList)
            {
                if (child.gameObject.name != "Img_element")
                {
                    // 如果不是，销毁该子物体
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
                    Debug.LogError("Element 的 Image 组件未找到！");
            }
        }

    }
}
