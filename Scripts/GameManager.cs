using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text scoreP1;
    public Text scoreP2;
    public Text win;
    public Text pause;
    private int p1, p2;
    public Transform b;
    public Camera cam;
    public Button playAgain;
    public Button quit;
    public Button main;
    public Renderer bg;
    public float speed;
    public static bool playable;
    private BallBehaviour ball;
    public AudioSource p1Score;
    public AudioSource p2Score;
    public AudioSource soundtrack;

    void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    private void Quit()
    {
        StopAllCoroutines();
        Application.Quit();
    }

    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Awake()
    {
        StopAllCoroutines();
        playAgain.onClick.AddListener(PlayAgain);
        quit.onClick.AddListener(Quit);
        main.onClick.AddListener(MainMenu);
        playable = true;
    }

    void Start()
    {
        p1 = p2 = 0;
        win.gameObject.SetActive(false);
        pause.gameObject.SetActive(false);
        playAgain.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        main.gameObject.SetActive(false);
        Time.timeScale = 1;
        ball = b.gameObject.GetComponent<BallBehaviour>();
        soundtrack.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pause.gameObject.SetActive(true);
                quit.gameObject.SetActive(true);
                main.gameObject.SetActive(true);
                soundtrack.pitch = 0.5f;
            }
            else
            {
                Time.timeScale = 1;
                pause.gameObject.SetActive(false);
                quit.gameObject.SetActive(false);
                main.gameObject.SetActive(false);
                soundtrack.pitch = 1.25f;
            }
        }
        if (b.transform.position.x > (cam.orthographicSize * 2))
        {
            p2++;
            b.gameObject.GetComponent<TrailRenderer>().enabled = false;
            BallReset();
            SetScoreP2();
            p2Score.Play();
            IncreaseBallSpeed();
        }
        if (b.transform.position.x < -(cam.orthographicSize * 2))
        {
            p1++;
            b.gameObject.GetComponent<TrailRenderer>().enabled = false;
            BallReset();
            SetScoreP1();
            p1Score.Play();
            IncreaseBallSpeed();
        }
        bg.material.mainTextureOffset = new Vector2(Time.time * speed, Time.time * speed);
       
    }

    void BallReset()
    {
        StartCoroutine(DelayedBall());
        ball.xspeed = (Random.Range(0, 2) == 0) ? -ball.xspeed : ball.xspeed;
        ball.yspeed = (Random.Range(0, 2) == 0) ? -ball.yspeed : ball.yspeed;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    IEnumerator DelayedBall()
    {
        b.transform.position = new Vector2(0, 0);
        playable = false;
        yield return new WaitForSeconds(1.0f);
        b.gameObject.GetComponent<TrailRenderer>().enabled = true;
        playable = true;
    }

    void SetScoreP1()
    {
        scoreP1.text = "Player 1: " + p1.ToString();
        if (p1 >= 5)
        {
            win.text = "Player 1 Wins!";
            win.gameObject.SetActive(true);
            Time.timeScale = 0;
            playAgain.gameObject.SetActive(true);
            quit.gameObject.SetActive(true);
            main.gameObject.SetActive(true);
            GetComponent<AudioSource>().Play();
            
        }
    }

    void SetScoreP2()
    {
        scoreP2.text = "Player 2: " + p2.ToString();
        if (p2 >= 5)
        {
            win.text = "Player 2 Wins!";
            win.gameObject.SetActive(true);
            Time.timeScale = 0;
            playAgain.gameObject.SetActive(true);
            quit.gameObject.SetActive(true);
            main.gameObject.SetActive(true);
            GetComponent<AudioSource>().Play();

        }
    }

    void IncreaseBallSpeed()
    {
        if (ball.xspeed < 0)
        {
            ball.xspeed = ball.xspeed - 0.5f;
        }
        else
        {
            ball.xspeed = ball.xspeed + 0.5f;
        }
        if (ball.yspeed < 0)
        {
            ball.yspeed = ball.yspeed - 0.5f;
        }
        else
        {
            ball.yspeed = ball.yspeed + 0.5f;
        }
    }
}
