using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraC : MonoBehaviour
{
    // ��ң���帳ֵ
    public Transform Player;
    // X�� ��������ұ�����
    public float MaxX;
    // X�� ��������������
    public float MinX;

    // ÿһ֡��ִ��һ��
    void Update()
    {
        // ������ң�����ֻ������ҵ�X������
        Vector3 newPos = new Vector3(Player.position.x, transform.position.y, transform.position.z);
        // �����������û�г��� �߽�
        newPos.x = Mathf.Clamp(newPos.x, MinX, MaxX);
        // �����������������
        transform.position = newPos;
    }
}
