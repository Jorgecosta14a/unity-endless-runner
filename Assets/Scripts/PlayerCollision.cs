using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.inst.Morrer();
        }
    }

    
    void Update()
    {
        
        if (transform.position.y < -2f) 
        {
            GameManager.inst.Morrer();
        }
    }
}