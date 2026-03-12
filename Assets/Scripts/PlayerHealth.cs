using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int vidas = 3;
    public float tiempoInvulnerable = 4f;

    bool esInvulnerable = false;

    Renderer playerRenderer;
    PlayerSounds playerSounds;

    // Referencias a UI
    public GameObject H1;
    public GameObject H2;
    public GameObject H3;
    public GameObject CanvasLose;

    void Start()
    {
        playerRenderer = GetComponentInChildren<Renderer>();
        playerSounds = GetComponent<PlayerSounds>();

        // Asegurarse que CanvasLose está desactivado al iniciar
        if(CanvasLose != null)
            CanvasLose.SetActive(false);
    }

    public void RecibirDaño(int daño)
    {
        if (esInvulnerable) return;

        vidas -= daño;
        Debug.Log("Vidas restantes: " + vidas);

        // Actualizar UI
        ActualizarCorazones();

        if (playerSounds != null)
            playerSounds.SonidoDano();

        if (vidas <= 0)
        {
            Morir();
            return;
        }

        StartCoroutine(Invulnerabilidad());
    }

    public void RecuperarVida(int cantidad)
    {
        vidas += cantidad;

        // Limitar máximo 3 vidas
        if (vidas > 3) vidas = 3;

        Debug.Log("Vidas restantes: " + vidas);

        ActualizarCorazones();

        if (playerSounds != null)
            playerSounds.SonidoRecompensa();
    }

    void ActualizarCorazones()
    {
        if(H1 != null) H1.SetActive(vidas >= 1);
        if(H2 != null) H2.SetActive(vidas >= 2);
        if(H3 != null) H3.SetActive(vidas >= 3);
    }

    IEnumerator Invulnerabilidad()
    {
        esInvulnerable = true;
        float tiempo = 0f;

        while (tiempo < tiempoInvulnerable)
        {
            playerRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);

            playerRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);

            tiempo += 0.4f;
        }

        esInvulnerable = false;
    }

    void Morir()
    {
        Debug.Log("Game Over");

        // Mostrar canvas de perder
        if(CanvasLose != null)
            CanvasLose.SetActive(true);

        // Pausar todo el juego
        Time.timeScale = 0f;


    }
}