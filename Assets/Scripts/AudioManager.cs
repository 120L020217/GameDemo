using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // ����ģʽ
    public static AudioManager Instance;
    // ��Ч���������
    private AudioSource audioSource;
    // ��ЧƬ������ 0����2�� 1�� ��2�ȵ��� ��3�Խ��
    public AudioClip[] audioClips;

    // ��Ϸһ��ʼִ��
    void Awake()
    {

        // ȷ���������Ƿ������Ч������
        // ���û��
        if (Instance == null)
        {
            // ��־������
            Instance = this;
            // ��Unity����Ҫ�����л���ʱ����������
            DontDestroyOnLoad(gameObject);

            // ������Ч���������
            audioSource = GetComponent<AudioSource>();
        }
        // ���û��
        else
        {
            // ˵���Լ��Ƕ���ģ������Լ�
            Destroy(gameObject);
        }

    }

    // ��鱳������
    public void CheckBG()
    {
        // �����������û���ڲ�����
        if (audioSource.isPlaying == false)
        {
            // ���ű�������
            audioSource.Play();
        }
    }
    // ������Ч ���ŵڼ������ǲ���Ҫ�رձ�������
    public void Play(int index, bool bgOver = false)
    {
        // �����Ҫ�رձ�������
        if (bgOver)
        {
            // ֹͣ��������
            audioSource.Stop();
        }
        // ����һ��ָ������Ч
        audioSource.PlayOneShot(audioClips[index]);
    }
}
