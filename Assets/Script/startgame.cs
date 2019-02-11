using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    public AudioSource Audio;

    public void LoadTheGame()
    {
        SceneManager.LoadScene(1);
    }
    public void playsound()
    {
        Audio.Play();
    }
}
