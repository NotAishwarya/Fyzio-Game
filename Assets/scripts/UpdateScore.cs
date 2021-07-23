using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UpdateScore : MonoBehaviour
{
    
   
    public TMP_Text missedText;
    public TMP_Text scoreText;
    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(System.DateTime.Now.ToString("MM / dd"));
        missedText.text = (ScoreCounter.misses).ToString();
        scoreText.text = (ScoreCounter.scoreTotal).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
