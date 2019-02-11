using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    AudioSource ExtraSound;
    Score score;
    Camera Camera;
    public GameObject Scoretext;
    public GameObject Menu;
    public bool GameStart = false;
    public Color[] ColorToChange;


    private void Start()
    {
        ExtraSound = GetComponent<AudioSource>();
        score = GetComponent<Score>();
        Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void Update()
    {
        gameStart();
        ColorChange();
        if(GameStart == false)
        {
            Scoretext.SetActive(false);
            Menu.SetActive(true);
        }
        else if (GameStart == true)
        {
            Scoretext.SetActive(true);
            Menu.SetActive(false);
        }
    }
    public void gameStart()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase ==  TouchPhase.Began)
            {
                GameStart = true;
            }
        }
        if (Input.GetButton("Fire1"))
        {
            GameStart = true;
        }
    }

    void ColorChange()
    {
        if (score.score == 0f)
        {
            Camera.backgroundColor = ColorToChange[0];
            
        }

        if (score.score == 10f)
        {
            ExtraSound.Play();
            Camera.backgroundColor = ColorToChange[1];
            
        }

        if (score.score == 20f)
        {
            Camera.backgroundColor = ColorToChange[2];
            ExtraSound.Play();
        }

        if (score.score == 50f)
        {
            Camera.backgroundColor = ColorToChange[3];
            ExtraSound.Play();
        }

        if (score.score == 100f)
        {
            Camera.backgroundColor = ColorToChange[4];
            ExtraSound.Play();
        }
    }
}
