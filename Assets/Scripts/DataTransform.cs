using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTransform : MonoBehaviour
{
    public static DataTransform Instance { get; private set; }
    public int HP { get; set; } = 3;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
