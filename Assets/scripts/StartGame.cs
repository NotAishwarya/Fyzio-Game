using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text hurdleCount;
    public TMP_Text welcomeText;

    void Start()
    {
        hurdleCount.text = (userData.hurdles).ToString();
        welcomeText.text = "Hey " + userData.name + ", Welcome back!!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startTheGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
