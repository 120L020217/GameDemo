using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisteryStoneController : MonoBehaviour
{
    public GameObject gos;
    public bool valid = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenGold()
    {
        if (valid)
        {
            //Vector3 pos = transform.position;
            //this.transform.position = new Vector3(5, this.transform.position.y, this.transform.position.z);
            Vector3 pos = new Vector3(transform.position.x, transform.position.y-0.45f, transform.position.z);
            Instantiate(gos, pos, Quaternion.identity);
        }
        valid = false;
        //Destroy(gameObject);
    }
}
