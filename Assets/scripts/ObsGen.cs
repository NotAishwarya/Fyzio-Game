using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsGen : MonoBehaviour
{
    public GameObject[] obs;
    public float spawnZ = -120;
   

    public int numberOfObs= 12;

    public int distanceBTWNobs = 30;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfObs; i++)
        {
            Instantiate(obs[0], transform.forward * spawnZ, transform.rotation);
            spawnZ += distanceBTWNobs;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
