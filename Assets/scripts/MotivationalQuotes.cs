using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MotivationalQuotes : MonoBehaviour
{
    public string[] quotes;
    public TMP_Text mQ;
    public string thiss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMQ()
    {
     
        thiss=quotes[Random.Range(0, quotes.Length)];
        mQ.text = quotes[Random.Range(0, quotes.Length)];
    }

    public void removeText()
    {
        mQ.text = "";
    }

    public void goodText()
    {
        mQ.text = "GOOD JOB";
    }
}
