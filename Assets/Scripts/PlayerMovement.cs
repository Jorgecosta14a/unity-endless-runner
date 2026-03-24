using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float sideSpeed = 5f;
    
    // Nova variável que controla o quão rápido o jogo acelera
    public float speedIncrease = 0.5f; 

    void Update()
    {
        // 1. Aumenta a velocidade gradualmente a cada segundo
        forwardSpeed += speedIncrease * Time.deltaTime;

        // 2. O teu código original: Move o boneco para a frente (agora cada vez mais rápido)
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // 3. O teu código original: Move o boneco para os lados com as setas/A e D
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * sideSpeed * Time.deltaTime);
    }
}