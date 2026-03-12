using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ReiniciarJuego : MonoBehaviour
{
    // Opcional: Canvas que quieras cerrar al reiniciar
    public GameObject canvasMenu;

    // Método que llamas desde el botón
    public void ReiniciarEscena()
    {
        // Si quieres, desactivas el canvas de menú u otros
        if(canvasMenu != null)
            canvasMenu.SetActive(false);

        // Restaurar Time.timeScale antes de recargar la escena
        Time.timeScale = 1f;

        // Usamos corutina para recargar la escena en la siguiente frame
        StartCoroutine(CargarEscena());
    }

    IEnumerator CargarEscena()
    {
        // Espera un frame para que Unity actualice todo
        yield return null;

        // Recargar la escena actual
        Scene escenaActual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escenaActual.name);

        Debug.Log("Escena recargada correctamente!");
    }
}