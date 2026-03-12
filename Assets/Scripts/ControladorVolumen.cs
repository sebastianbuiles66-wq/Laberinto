using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorVolumen : MonoBehaviour
{
    [Header("Sliders")]
    public Slider SliderMusic;
    public Slider SliderSFX;

    [Header("AudioSources")]
    public AudioSource Musica;        // AudioSource de la música de fondo
    private AudioSource[] Efectos;    // Todos los AudioSources de efectos en la escena

    void Start()
    {
        // -------------------------------
        // 1️⃣ Cargar volúmenes guardados
        // -------------------------------
        if (Musica != null)
            Musica.volume = PlayerPrefs.GetFloat("VolMusica", 1f);

        // Buscar todos los AudioSources en la escena
        AudioSource[] todos = FindObjectsOfType<AudioSource>();

        // Filtrar: agregar solo los que no sean la música
        List<AudioSource> efectosList = new List<AudioSource>();
        foreach (AudioSource s in todos)
        {
            if (s != Musica) // Excluye la música de fondo
                efectosList.Add(s);
        }
        Efectos = efectosList.ToArray();

        // Aplicar volumen guardado a los efectos
        float volEfectos = PlayerPrefs.GetFloat("VolEfectos", 1f);
        foreach (AudioSource s in Efectos)
        {
            if (s != null)
                s.volume = volEfectos;
        }

        // -------------------------------
        // 2️⃣ Inicializar sliders
        // -------------------------------
        if (SliderMusic != null) SliderMusic.value = Musica != null ? Musica.volume : 1f;
        if (SliderSFX != null) SliderSFX.value = Efectos.Length > 0 ? Efectos[0].volume : 1f;

        // -------------------------------
        // 3️⃣ Asignar listeners para cambios en tiempo real
        // -------------------------------
        if (SliderMusic != null) SliderMusic.onValueChanged.AddListener(SetMusicaVolume);
        if (SliderSFX != null) SliderSFX.onValueChanged.AddListener(SetEfectosVolume);
    }

    // -------------------------------
    // Ajusta el volumen de la música
    // -------------------------------
    public void SetMusicaVolume(float value)
    {
        if (Musica != null)
            Musica.volume = value;

        PlayerPrefs.SetFloat("VolMusica", value);
    }

    // -------------------------------
    // Ajusta el volumen de todos los efectos
    // -------------------------------
    public void SetEfectosVolume(float value)
    {
        foreach (AudioSource s in Efectos)
        {
            if (s != null)
                s.volume = value;
        }

        PlayerPrefs.SetFloat("VolEfectos", value);
    }
}