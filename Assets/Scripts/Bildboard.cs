using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bildboard : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Camera.main != null)
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0);                    // �ؽ�Ʈ ������ ����
        }
    }
}
