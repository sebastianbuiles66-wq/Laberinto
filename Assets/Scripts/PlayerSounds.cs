using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip salto;
    public AudioClip caminar;
    public AudioClip correr;
    public AudioClip dano;
    public AudioClip recompensa;

    public void SonidoSalto()
    {
        audioSource.PlayOneShot(salto);
    }

    public void SonidoCaminar()
    {
        audioSource.PlayOneShot(caminar);
    }

    public void SonidoCorrer()
    {
        audioSource.PlayOneShot(correr);
    }

    public void SonidoDano()
    {
        audioSource.PlayOneShot(dano);
    }

    public void SonidoRecompensa()
    {
        audioSource.PlayOneShot(recompensa);
    }
}