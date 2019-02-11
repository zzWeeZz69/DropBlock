using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    AudioSource Pling;
    public AudioSource Hit;
    public Score score;
    float YOffset = -3.6f;
    public float Mapwidth = 5f;
    Rigidbody2D rbody;
    bool DisableScore = true;


    GameController GameController;
    // Start is called before the first frame update
    void Start()
    {
        Pling = GetComponent<AudioSource>();

        rbody = GetComponent<Rigidbody2D>();
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.GameStart == true)
        {
            if (DisableScore == true)
            {
                if (Input.GetButton("Fire1"))
                {
                    Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 newPosition = new Vector3(point.x, YOffset, transform.position.z);
                    newPosition.x = Mathf.Clamp(newPosition.x, -Mapwidth, Mapwidth);
                    rbody.position = newPosition;
                }
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ScoreBlock")
        {
            // do nothing
        }
        else
        {
            DisableScore = false;
            Hit.Play();
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DisableScore == true)
        {
            score.score++;
            Pling.Play();
        }
        else if (DisableScore == false)
        {
            
            Pling.Pause();
        }
    }
}
