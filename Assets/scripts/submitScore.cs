using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Firebase;
//using Firebase.Extensions;
//using Firebase.Firestore;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class submitScore : MonoBehaviour
{
   // FirebaseFirestore db;
    public InputField comment;
    public GameObject bgPanel;
    public GameObject scoreboard;
    public TMP_Text registeredText;

    private void Awake()
    {
       // db = FirebaseFirestore.DefaultInstance;
    }
 
    public void submitToDB()
    {
         Debug.Log("Score submitted");
        /*  db.Collection("users").Document(userData.uid).Collection("history").Document().SetAsync(new Dictionary<string, string>
           {
               {"date",System.DateTime.Now.ToString() },
               {"score", (ScoreCounter.misses).ToString() },
               {"comment", comment.text },
           }).ContinueWithOnMainThread(task =>
           {
               Debug.Log("ADDED");
               scoreboard.SetActive(false);
               bgPanel.SetActive(false);
               registeredText.text = "Your score has been registered!";
           });*/

        scoreboard.SetActive(false);
        bgPanel.SetActive(false);
        registeredText.text = "Your score has been registered!";
    }
    


}
