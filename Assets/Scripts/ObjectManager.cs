using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // �� Inspector ������Ҫ����ͽ��õ� GameObject
    public GameObject objectToActivate;   // ������� GameObject ��������
    public GameObject objectToDeactivate; // �����õ� GameObject ��������

    // �������л�����ļ���״̬
    public void ToggleObjects()
    {
        if (objectToActivate != null && objectToDeactivate != null)
        {
            objectToActivate.SetActive(true);   // ����ָ������
            objectToDeactivate.SetActive(false); // ����ָ������
        }
        else
        {
            Debug.LogError("���� Inspector ������ GameObject��"); // ����Ƿ�����
        }
    }
}
