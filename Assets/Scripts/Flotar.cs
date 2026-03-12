using UnityEngine;

public class Flotar : MonoBehaviour
{
    public float velocidad = 2f;
    public float altura = 0.25f;
    public float rotacion = 50f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Movimiento arriba y abajo
        float nuevaAltura = Mathf.Sin(Time.time * velocidad) * altura;
        transform.position = posicionInicial + new Vector3(0, nuevaAltura, 0);

        // Rotación
        transform.Rotate(0, rotacion * Time.deltaTime, 0);
    }
}