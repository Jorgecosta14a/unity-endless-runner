using UnityEngine;

public class SpawnNewGround : MonoBehaviour
{
    GroundSpawner groundSpawner;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Alguém tocou no gatilho: " + other.gameObject.name); 

        if (other.CompareTag("Player"))
        {
            groundSpawner.SpawnTile();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject, 2f);
        }
    }
}