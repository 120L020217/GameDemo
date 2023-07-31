using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SettleManager : MonoBehaviour
{
    public static SettleManager Instance;
    private int HPNum;
    private Text HPText;

    public int HPNUM
    {
        get => HPNum;

        set
        {
            HPNum = value;
            HPText.text = "x  " + HPNum;
        }
    }

    private void Awake()
    {
        Debug.Log("Scene Settlement Awake() invoked!");
        Instance = this;
        HPText = transform.Find("Player/Text (Legacy)").GetComponent<Text>();
        HPNUM = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Scene Settlement Start() invoked!");
        HPNUM = DataTransform.Instance.HP;
        if (HPNUM <= 0)
        {
            HPText.text = "You LOSE";
        }
        if (DataTransform.Instance.HP > 0)
        {
            Invoke("Revive", 3.5f);
        }
    }

    public void Revive()
    {
        Debug.Log("cjm" + SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MarioDemo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
