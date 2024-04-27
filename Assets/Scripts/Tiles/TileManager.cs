using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private List<GameObject> activeTiles;
    public GameObject[] tilePrefabs;

    public float tileLength = 30;
    public int numberOfTiles = 3;
    public int totalNumOfTiles = 8;

    public float zSpawn = 0;

    private Transform playerTransform;

    private int previousIndex;

    void Start()
    {
        activeTiles = new List<GameObject>();
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {

                SpawnTile();
            }

            else
               
                SpawnTile(Random.Range(0, totalNumOfTiles));
        }

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        Debug.Log("numberOfTiles * tileLength " + numberOfTiles * tileLength);
        Debug.Log("zSpawn - (numberOfTiles * tileLength) " + (zSpawn - (numberOfTiles * tileLength)));
        Debug.Log("aSpawn " + zSpawn);
        Debug.Log("playerTransform.position.z " + playerTransform.position.z);
        Debug.Log("playerTransform.position.z -30 " + (playerTransform.position.z -30));

        //logic for spawn tile
        //30 is gia tri lui lai de spawn cung voi player
        // khi run , player se + position len , cho den khi no lon hon zspawn  - numberOfTiles * tileLength (numberOfTiles * tileLength luôn 90 , so thay doi la zspawn khi moi ln SpawnTile se + them 30)
        if (playerTransform.position.z  >= zSpawn - (numberOfTiles * tileLength ) +30 )
        {
            //if player pos 
            int index = Random.Range(0, totalNumOfTiles);
            while(index == previousIndex)
                index = Random.Range(0, totalNumOfTiles);

            DeleteTile();
            SpawnTile(index);
        }
            
    }

    public void SpawnTile(int index = 0)
    {
        GameObject tile = tilePrefabs[index];
       if (tile.activeInHierarchy)
            tile = tilePrefabs[index + 8];

        if(tile.activeInHierarchy)
            tile = tilePrefabs[index + 16];

        tile.transform.position = Vector3.forward * zSpawn;
        tile.transform.rotation = Quaternion.identity;
        tile.SetActive(true);
        Debug.Log("zspawn0" + zSpawn);

        activeTiles.Add(tile);
        zSpawn += tileLength;
        previousIndex = index;
    }

    private void DeleteTile()
    {
        activeTiles[0].SetActive(false);
        activeTiles.RemoveAt(0);
        PlayerManager.score += 3;
    }
}
