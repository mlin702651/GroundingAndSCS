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

    public int hardMode; // change the mode
    public int tileCounter;


    // Start is called before the first frame update
    void Start()
    {
        zSpawn += tileLength;
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i < 3) SpawnTile(0);
            else SpawnTile(Random.Range(0, 4));
        }

        hardMode = 1;
        tileCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //*** First Tile ***//



        //*** Mode Changing ***//
        if (tileCounter % 6 == 0) hardMode++;



        //*** Tile spawning ***//
        if (hardMode == 1) // Mode 1
        {
            // spawn tile when it moves forward
            if (playerTransform.position.z > zSpawn - (numberOfTiles - 1.1) * tileLength)
            {
                SpawnTile(Random.Range(0, 5));
                DeleteTile();
                tileCounter++;
            }
        }
        else if (hardMode == 2) // Mode 2
        {
            // spawn tile when it moves forward
            if (playerTransform.position.z > zSpawn - (numberOfTiles - 1.1) * tileLength)
            {
                SpawnTile(Random.Range(6, 11));
                DeleteTile();
                tileCounter++;
            }
        }
        else if (hardMode == 3) // Mode 3
        {
            // spawn tile when it moves forward
            if (playerTransform.position.z > zSpawn - (numberOfTiles - 1.1) * tileLength)
            {
                SpawnTile(Random.Range(12, 17));
                DeleteTile();
                tileCounter++;
            }
        }

    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        go.transform.Rotate(0, 180, 0);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
