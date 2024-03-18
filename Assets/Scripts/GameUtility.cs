using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUtility : MonoBehaviour
{
    public void LoadScene(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void MuteToggleBackgroundMusic()
    {
        SoundManager.instance.ToogleBacgroundMusic();
    }

    public void MutetoggleSoundFX()
    {
        SoundManager.instance.ToggleSoundFX();
    }
}
