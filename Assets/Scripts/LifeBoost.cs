using UnityEngine;

public class LifeBoost : MonoBehaviour
{
    public int vidaRecuperada = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if(playerHealth != null)
            {
                playerHealth.RecuperarVida(vidaRecuperada); // ✅ Usamos el método de PlayerHealth

                Debug.Log("Vida recuperada");
            }

            // reproducir sonido de recompensa
            PlayerSounds sounds = other.GetComponent<PlayerSounds>();

            if (sounds != null)
            {
                sounds.SonidoRecompensa();
            }

            Destroy(gameObject);
        }
    }
}