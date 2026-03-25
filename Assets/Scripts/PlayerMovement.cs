using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float sideSpeed = 5f;
    
    public float speedIncrease = 0.5f; 

    void Update()
    {
        forwardSpeed += speedIncrease * Time.deltaTime;

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * sideSpeed * Time.deltaTime);
    }
}