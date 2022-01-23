using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownTimer : MonoBehaviour
{

    float currentTime = 0f;
    float startingTime = 12f;

    public AudioClip LoseSound;

    public GameObject loseTextObject;

    [SerializeField] Text countdownText;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;

        audioSource = GetComponent<AudioSource>();

        loseTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;

            loseTextObject.SetActive(true);

            Time.timeScale = 0f;

            PlaySound(LoseSound);
        }
                
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
