using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 10f;
    public float lifeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab);

        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bulletSpawn.parent.GetComponent<Collider>());

        bullet.transform.position = bulletSpawn.position;

        Vector3 rotation = bullet.transform.rotation.eulerAngles;

        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y ,rotation.z);

        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.up * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestoryBulletAfterTime(bullet, lifeTime));


    }

    private IEnumerator DestoryBulletAfterTime(GameObject bullet, float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
