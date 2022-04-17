using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;

    private float jumpVelocity = 400f;
    private float tiltSmooth = 1;

    private Quaternion downRotation;
    private Quaternion forwardRotation;

    public static int score = 0;

    private float hoverSpeed = 3f;
    private float hoverLimit = 1f;

    public AudioSource scoreAudio;
    public AudioSource gameoverAudio;

    public static bool gameover = false;
    public static bool gameStarted = false;

    public Text beginText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // rotation effects values
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);

        score = 0;
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            Begin();
        }

        if (Input.touchCount == 1 && !gameover) //space or left mouse button //Input.GetKeyDown(KeyCode.Space)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                gameStarted = true;
                Destroy(beginText);
                rb.gravityScale = 2f;
                Jump();
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            Destroy(beginText);
            rb.gravityScale = 2f;
            Jump();
        }

        if (gameStarted)
        {
            // downward tilt
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
        }
    }

    void Jump()
    {
        transform.rotation = forwardRotation;

        //tapping effect
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector2.up * jumpVelocity);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            Time.timeScale = 0;
            gameover = true;
            gameoverAudio.Play();

            if(score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

            SceneManager.LoadScene("GameoverMenu");

        }

        if (collision.gameObject.tag == "ScoreChecker")
        {
            score++;
            scoreAudio.Play();
            UnityEngine.Debug.Log(score);
        }
    }

    void Begin()
    {
        rb.gravityScale = 0f;

        if (transform.position.y >= hoverLimit && hoverSpeed > 0)
        {
            hoverSpeed *= -1;
        }
        if (transform.position.y <= -hoverLimit && hoverSpeed < 0)
        {
            hoverSpeed *= -1;
        }

        transform.Translate(Vector3.up * hoverSpeed * Time.deltaTime, Space.World);
    }
}
