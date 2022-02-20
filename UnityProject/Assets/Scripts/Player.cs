using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public int coin;
    public GameObject coinText;

    private float scorevalue;
    public float totalcoins;
    public float timeleft;
    public int timeRemaining;

    public Text ScoreText;
    public Text TimerText;

    private float TimerValue;

    public ParticleSystem particles;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        timeRemaining = Mathf.FloorToInt(timeleft % 60);
        TimerText.text = "Timer : " + timeRemaining.ToString();

        if(coin == totalcoins)
        {
            if(timeleft<=TimerValue)
            {
                SceneManager.LoadScene("GameWin");
            }
        }
        else if(timeleft <=0.1)
        {
            SceneManager.LoadScene("GameLose");
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            audioSource.Play();
            Debug.Log("touch");
            Destroy(collision.gameObject);
            coin += 10 ;
            coinText.GetComponent<Text>().text = "Score: " + coin;
            particles.Play();
            
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}