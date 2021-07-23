using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTiles : MonoBehaviour
{
    public GameObject[] tiles;
    public float spawnZ = 300;
    public float tileLenght = 300f;

    public int numberOfTiles = 2;
    public List<GameObject> activeTiles;

    public Transform playerTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < numberOfTiles; i++)
        {
            spawnTile(Random.Range(0, tiles.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerTransform.position.z - 300 > spawnZ - (numberOfTiles * tileLenght)))
        {
            spawnTile(Random.Range(0, tiles.Length));
            DeleteTile();
        }

    }

    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);


    }
    public void spawnTile(int tileIndex)
    {
        GameObject go=Instantiate(tiles[tileIndex], transform.forward * spawnZ, transform.rotation);
        activeTiles.Add(go);
        spawnZ += tileLenght;
    }
}
