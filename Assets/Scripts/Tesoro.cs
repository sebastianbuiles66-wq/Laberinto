using UnityEngine;
using TMPro;

public class Tesoro : MonoBehaviour
{
    [Header("UI y Canvas")]
    public GameObject CanvasWin;           // Canvas de victoria
    public TextMeshProUGUI scoreText;      // Texto que mostrará el score

    private GameTimer gameTimer;           // Referencia al GameTimer

    private void Start()
    {
        // Buscar automáticamente el GameTimer en la escena
        gameTimer = FindObjectOfType<GameTimer>();
        if(gameTimer == null)
            Debug.LogWarning("No se encontró GameTimer en la escena.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("¡Ganaste!");

            // Pausar juego
            Time.timeScale = 0f;

            if(gameTimer != null)
            {
                // Calcular score sumando tiempo principal + tiempo de poción
                float score = gameTimer.timeLeft + gameTimer.GetTiempoPocion();

                // Actualizar texto del CanvasWin
                if(scoreText != null)
                    scoreText.text = "Score: " + score.ToString("F2"); // 2 decimales
            }

            // Activar CanvasWin
            if(CanvasWin != null)
                CanvasWin.SetActive(true);
        }
    }
}