using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
    {
        print(other.name + " !");
        Destroy(other);
    }
}
