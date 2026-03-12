using UnityEngine;
using System.Collections;

public class StartAnimationDelay : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        // Desactivar animator al inicio
        anim.enabled = false;

        // Iniciar coroutine
        StartCoroutine(DelayAnimation());
    }

    IEnumerator DelayAnimation()
    {
        // Esperar 1 segundo
        yield return new WaitForSeconds(3f);

        // Activar animator
        anim.enabled = true;
    }
}