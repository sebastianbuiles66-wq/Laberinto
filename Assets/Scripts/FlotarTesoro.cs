using UnityEngine;

public class FlotarTesoro : MonoBehaviour
{
    public float velocidad = 2f;
    public float altura = 0.25f;
    public float rotacion = 0f;

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