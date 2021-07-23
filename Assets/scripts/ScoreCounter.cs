using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static int scoreTotal;
    public static int misses;
    public TMP_Text miss;
    public TMP_Text hit;
    public boy boys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hit.text = boys.total.ToString();
        miss.text = boys.count.ToString();
        scoreTotal = boys.total;
        misses = boys.count;

    }

   
   


}
