using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Extensions;
using Firebase.Firestore;

public class dumm : MonoBehaviour
{
    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
    // Start is called before the first frame update

    FirebaseFirestore db;
    private void Awake()
    {
        db = FirebaseFirestore.DefaultInstance;
        methodCall();
        methodInsert();
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
    public void methodInsert()
    {
        DocumentReference docRef = db.Collection("users").Document("125");
        Dictionary<string, object> city = new Dictionary<string, object>
{
        { "Name", "Panda" },
        { "Hurdles", "50" },
};
        docRef.SetAsync(city).ContinueWithOnMainThread(task => {
            Debug.Log("Added data to the LA document in the cities collection.");
        });
    }
    public void methodCall()
    {
        Debug.Log("This");



        DocumentReference docRef = db.Collection("users").Document("123");
        Debug.Log("Here");
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {
                Debug.Log("Document data for {0} document:" + snapshot.Id);
                Dictionary<string, object> city = snapshot.ToDictionary();
                foreach (KeyValuePair<string, object> pair in city)
                {
                    Debug.Log(pair.Key + ":" + pair.Value);
                }
            }
            else
            {
                Debug.Log("Np doc");
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
