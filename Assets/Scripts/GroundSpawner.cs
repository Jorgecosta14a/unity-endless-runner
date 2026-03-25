using UnityEngine;
using System.Collections.Generic; 

public class GroundSpawner : MonoBehaviour
{
    [Header("Referências")]
    public Transform player; 
    public GameObject[] groundTiles; 
    
    [Header("Configurações")]
    private float spawnZ = 0f;       
    private float tileLength = 20f;  
    private int tilesOnScreen = 5;   
    
    
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        
        for (int i = 0; i < tilesOnScreen; i++)
        {
            if (i == 0) 
                SpawnTile(0); 
            else 
                SpawnTile(Random.Range(0, groundTiles.Length));
        }
    }

    void Update()
    {
        
        
        if (player.position.z - tileLength > spawnZ - (tilesOnScreen * tileLength))
        {
            
            SpawnTile(Random.Range(0, groundTiles.Length));
            
            
            DeleteOldTile();
        }
    }

    private void SpawnTile(int prefabIndex)
    {
        
        GameObject go = Instantiate(groundTiles[prefabIndex], new Vector3(0, 0, spawnZ), Quaternion.identity);
        
        
        activeTiles.Add(go);
        
        
        spawnZ += tileLength;
    }

    private void DeleteOldTile()
    {
        
        Destroy(activeTiles[0]);
        
       
        activeTiles.RemoveAt(0);
    }
}