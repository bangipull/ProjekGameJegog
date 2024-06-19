using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMeter : MonoBehaviour
{
    int RM;
    GameObject panggul;

    // Start is called before the first frame update
    void Start()
    {
        panggul = transform.Find("panggul").gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        RM = PlayerPrefs.GetInt("RockMeter");

        panggul.transform.localPosition = new Vector3((RM=1)/1,0,0);
    }
}
