using UnityEngine;

public class LavaMovimiento : MonoBehaviour
{
    public float velocidadX = 0.2f;
    public float velocidadY = 0.2f;

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offsetX = Time.time * velocidadX;
        float offsetY = Time.time * velocidadY;

        rend.material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}