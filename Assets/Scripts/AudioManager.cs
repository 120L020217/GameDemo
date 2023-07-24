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

    private bool isPlaying = true;

    // ��Ϸһ��ʼִ��
    void Awake()
    {

        // ȷ���������Ƿ������Ч������
        if (Instance == null)
        {
            // ��־������
            Instance = this;
            // ��Unity����Ҫ�����л���ʱ����������
            DontDestroyOnLoad(gameObject);

            // ������Ч���������
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            // ˵���Լ��Ƕ���ģ������Լ�
            Destroy(gameObject);
        }

    }

    // ��鱳������
    public void CheckBG()
    {
        Debug.Log(audioSource.isPlaying);
        // �����������û���ڲ�����
        if (isPlaying == false)
        {
            audioSource.Play();
            isPlaying = true;
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
            isPlaying = false;
        }
        // ����һ��ָ������Ч
        audioSource.PlayOneShot(audioClips[index]);
    }
}
