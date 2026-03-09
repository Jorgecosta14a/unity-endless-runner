using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] groundTiles; 
    
    public int numberOfTiles = 15;
    float nextZPos = 0f; 

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        int randomNum = Random.Range(0, groundTiles.Length);

        Instantiate(groundTiles[randomNum], new Vector3(0, 0, nextZPos), Quaternion.identity);
        
        nextZPos += 20f; 
    }
}