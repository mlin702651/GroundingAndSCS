using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs; // the tiles
    public Transform playerTransform; // get player's transform

    public float zSpawn = 0;
    public float tileLength;
    public int numberOfTiles = 5;
    public List<GameObject> activeTiles = new List<GameObject>();

    public int hardMode;
    public int tileCounter;


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i < 3) SpawnTile(0);
            else SpawnTile(Random.Range(0, 4));
        }

        hardMode = 1;
        tileCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if( playerTransform.position.z > zSpawn - (numberOfTiles - 1.1) * tileLength )
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
        */


        if (hardMode == 0) // Easy Mode
        {
            if (playerTransform.position.z > zSpawn - (numberOfTiles - 1.1) * tileLength)
            {
                if (tileCounter == 0) { SpawnTile(0); DeleteTile(); tileCounter++; }
                else if (tileCounter == 1) { SpawnTile(Random.Range(0, 4)); DeleteTile(); tileCounter++; }
                else if (tileCounter == 2) { SpawnTile(Random.Range(1, 4)); DeleteTile(); tileCounter = 0; }
            }
        }
        else if (hardMode == 1) // Normal Mode
        {
            if (playerTransform.position.z > zSpawn - (numberOfTiles - 1.1) * tileLength)
            {
                if (tileCounter == 0) { SpawnTile(0); DeleteTile(); tileCounter++; }
                else if (tileCounter == 1) { SpawnTile(Random.Range(1, 4)); DeleteTile(); tileCounter++; }
                else if (tileCounter == 2) { SpawnTile(Random.Range(1, 7)); DeleteTile(); tileCounter = 0; }
            }
        }

    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
