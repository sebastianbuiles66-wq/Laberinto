using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int daño = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador tocó el obstáculo");

            PlayerHealth health = other.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.RecibirDaño(daño);
            }
        }
    }
}