using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private Text goldText;
    private int goldNum;

    public int GoldNum
    {
        get => goldNum;

        set
        {
            goldNum = value;
            goldText.text = "X  " + goldNum;
        }
    }

    private void Awake()
    {
        Instance = this;
        goldText = transform.Find("Gold/Text (Legacy)").GetComponent<Text>();

    }

    /*private void Start()
    {
        goldText.text = "X  " + 0;
    }

    private void Update()
    {
        goldText.text = "X  " + goldNum;
    }*/
}
