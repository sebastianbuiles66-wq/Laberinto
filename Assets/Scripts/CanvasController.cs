using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [Header("Lista de menús (Canvas o Paneles)")]
    public GameObject[] menus;

    // Activa solo el menú indicado por índice
    public void ActivarMenu(int index)
    {
        // Recorre todos los menús
        for (int i = 0; i < menus.Length; i++)
        {
            // Activa solo el seleccionado, desactiva los demás
            menus[i].SetActive(i == index);
            Debug.Log("Activando menú: " + index);
        }
    }
}
