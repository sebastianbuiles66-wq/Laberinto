using UnityEngine;

// Este script controla el potenciador de tiempo
public class TimeBoost : MonoBehaviour
{
    // Referencia al temporizador del juego
    public GameTimer gameTimer;

    // Cantidad de tiempo que se suma
    public float extraTime = 10f;

    void OnTriggerEnter(Collider other)
    {
        // Verifica si quien tocó el objeto es el jugador
        if (other.CompareTag("Player"))
        {
            // Sumar tiempo
            gameTimer.AddTime(extraTime);
            // reproducir sonido de recompensa
            PlayerSounds sounds = other.GetComponent<PlayerSounds>();

            if (sounds != null)
            {
                sounds.SonidoRecompensa();
            }

            // Destruir el potenciador
            Destroy(gameObject);
        }
    }
}