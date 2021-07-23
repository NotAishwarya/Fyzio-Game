using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Extensions;
using Firebase.Firestore;

public class Chumma : MonoBehaviour
{
 
    // Start is called before the first frame update
    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
    FirebaseFirestore db;
    private void Awake()
    {
        db = FirebaseFirestore.DefaultInstance;
        methodCall();
       
    }

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //InitializeFirebase();
                Debug.Log("ok");
                // methodCall();
                Debug.Log("Yes");
            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    public void methodCall()
    {
        /*  DocumentReference docRef = db.Collection("users").Document("123History");
          Dictionary<string, object> city = new Dictionary<string, object>
          {
              { "4", new Dictionary<string, string>{
                       { "date", "10023230" },
                       { "missScore", "10" },
                  {"comment", "Session was challenging" },
             } },
          };
          docRef.SetAsync(city, SetOptions.MergeAll).ContinueWithOnMainThread(task => {
              Debug.Log("Added data");
          });*/

        db.Collection("users").Document("124").Collection("history").Document().SetAsync(new Dictionary<string, string>
        {
            {"date","11052004" },
            {"score", "30" },
            {"comment", "Challenging" },
        }).ContinueWithOnMainThread(task =>
        {
            Debug.Log(task);
            Debug.Log("Added");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
