using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour

{
     [SerializeField] private float speed;
    private Rigidbody2D body;

    public ParticleSystem smokeEffect;

    public GameObject PickUp;


    public AudioClip PickSound;

    public AudioClip WinSound;

    public GameObject winTextObject;
    public GameObject loseTextObject;


    public TextMeshProUGUI countText;

    private int count;

    bool gameOver = true;

    AudioSource audioSource;

    public static bool gameIsPaused;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.P))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    private void FixedUpdate()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;
            SetCountText();

            Instantiate(smokeEffect, transform.position + Vector3.up * 0.5f, Quaternion.identity);

            PlaySound(PickSound);
        }
    }

    void SetCountText()
    {
        countText.text = "Oxygen: " + count.ToString();


        if (count >= 5)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);

            
                Time.timeScale = 0f;

            PlaySound(WinSound);
        }
    }
    

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }



}