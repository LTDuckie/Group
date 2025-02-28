using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // 在 Inspector 中设置要激活和禁用的 GameObject
    public GameObject objectToActivate;   // 将激活的 GameObject 拖入这里
    public GameObject objectToDeactivate; // 将禁用的 GameObject 拖入这里

    // 方法：切换对象的激活状态
    public void ToggleObjects()
    {
        if (objectToActivate != null && objectToDeactivate != null)
        {
            objectToActivate.SetActive(true);   // 激活指定对象
            objectToDeactivate.SetActive(false); // 禁用指定对象
        }
        else
        {
            Debug.LogError("请在 Inspector 中设置 GameObject！"); // 检查是否设置
        }
    }
}
