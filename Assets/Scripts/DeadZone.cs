using UnityEngine;
using UnityEngine.SceneManagement;


public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the dead zone!");
            // Aquí puedes agregar lógica adicional, como reiniciar el nivel o mostrar una pantalla de Game Over.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia el nivel actual
        }
    }
}
