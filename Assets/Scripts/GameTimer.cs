using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [Header("Temporizador principal")]
    public float timeLeft = 60f;
    public TextMeshProUGUI Tiempo; // Objeto del canvas que muestra el tiempo principal

    [Header("Temporizador pocion")]
    public TextMeshProUGUI Potions; // Objeto del canvas que muestra tiempo de la pocion
    private float tiempoPocion = 0f;
    private bool pocionActiva = false;

    [Header("Canvas Game Over")]
    public GameObject CanvasLose;

    private bool gameOver = false;

    void Start()
    {
        if(CanvasLose != null)
            CanvasLose.SetActive(false);

        ActualizarTiempoUI();
        ActualizarPocionUI();
    }

    void Update()
    {
        if (gameOver) return;

        // Si hay pocion activa, descontar tiempo de pocion
        if (pocionActiva)
        {
            tiempoPocion -= Time.deltaTime;
            if (tiempoPocion <= 0f)
            {
                tiempoPocion = 0f;
                pocionActiva = false;
            }
            ActualizarPocionUI();
        }
        else
        {
            // Restar tiempo principal
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0f)
            {
                timeLeft = 0f;
                GameOver();
            }
            ActualizarTiempoUI();
        }
    }

    // Función para recoger pocion
    public void AddTime(float seconds)
    {
        if(!pocionActiva)
        {
            tiempoPocion = seconds;
            pocionActiva = true;
        }
        else
        {
            // Sumar tiempo si ya hay una pocion activa
            tiempoPocion += seconds;
        }

        ActualizarPocionUI();
        Debug.Log("Se añadieron " + seconds + " segundos de pocion");
    }

    void ActualizarTiempoUI()
    {
        if(Tiempo != null)
            Tiempo.text = Mathf.Ceil(timeLeft).ToString();
    }

    void ActualizarPocionUI()
    {
        if(Potions != null)
            Potions.text = Mathf.Ceil(tiempoPocion).ToString();
    }

    void GameOver()
    {
        gameOver = true;

        if(CanvasLose != null)
            CanvasLose.SetActive(true);

        Time.timeScale = 0f;
        Debug.Log("Game Over por tiempo!");
    }

    // Reiniciar el temporizador (llamado desde el botón de reinicio)
    public void ResetTimer()
    {
        timeLeft = 60f;
        tiempoPocion = 0f;
        pocionActiva = false;
        gameOver = false;

        if(CanvasLose != null)
            CanvasLose.SetActive(false);

        Time.timeScale = 1f;
        ActualizarTiempoUI();
        ActualizarPocionUI();
    }

    public float GetTiempoPocion()
    {
        return tiempoPocion;
    }
}