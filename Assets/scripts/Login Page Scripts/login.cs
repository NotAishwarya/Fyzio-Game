using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Firebase;
//using Firebase.Extensions;
//using Firebase.Firestore;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour
{
    public InputField uid;
   // FirebaseFirestore db;
    public GameObject prompt;
    // Start is called before the first frame update
    private void Awake()
    {
       // db = FirebaseFirestore.DefaultInstance;
    }
    void Start()
    {
       /* FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            DependencyStatus dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
        */
    }

    public void onLoginClick()
    {
        string userId = uid.text;
        Debug.Log(userId);
        /* DocumentReference docRef = db.Collection("users").Document(userId);

         docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
         {
             DocumentSnapshot snapshot = task.Result;
             if (snapshot.Exists)
             {
                 Debug.Log("YES");

                 Dictionary<string, object> user = snapshot.ToDictionary();

                 userData.name = (string) user["name"];
                 userData.hurdles = int.Parse((string) user["hurdles"]);
                 userData.uid = userId;

                 Debug.Log(userData.name + " " + userData.hurdles);

                 SceneManager.LoadScene("start");

             }
             else
             {
                 StartCoroutine(tryagainPrompt());
                 Debug.Log("wrong user id");
             }
         });
         */
        userData.name = "Froddo";

        //change below value based on your needs
        userData.hurdles = 10;
        userData.uid = userId;
        SceneManager.LoadScene("start");


    }

    public IEnumerator tryagainPrompt()
    {
        prompt.SetActive(true);
        yield return new WaitForSeconds(1f);

        prompt.SetActive(false);
        uid.text = "";
        yield break;

    }


}
