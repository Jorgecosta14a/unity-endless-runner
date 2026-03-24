using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // 1. Morrer se bater de caras na parede
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.inst.Morrer();
        }
    }

    // 2. Morrer se cair para o abismo
    void Update()
    {
        // Se a altura (Y) do boneco for menor que -2, ele já caiu da estrada!
        if (transform.position.y < -2f) 
        {
            GameManager.inst.Morrer();
        }
    }
}