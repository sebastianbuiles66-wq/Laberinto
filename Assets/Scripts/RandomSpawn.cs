using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    // Array para guardar los puntos de aparición
    public Transform[] spawnPoints;

    void Start()
    {
        // Elegir un número aleatorio entre 0 y la cantidad de puntos
        int randomIndex = Random.Range(0, spawnPoints.Length);

        // Mover al jugador a esa posición
        transform.position = spawnPoints[randomIndex].position;
    }
}