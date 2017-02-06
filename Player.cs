using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Player : MonoBehaviour
{
    public float power = 500;
    public int jumpHeight = 1000;
    public bool isFalling = false;
    public int score;
    public int highScore;

    public Text SCORE;
    public GameObject YOUDIED;

    private int health = 3;
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;

    private bool canDoubleJump;
    private bool jumpOne;
    private bool jumpTwo;

	void Start ()
    {
        YOUDIED.SetActive(false);
        highScore = PlayerPrefs.GetInt("Highscore", 0);

        jumpOne = false;
        jumpTwo = false;
        canDoubleJump = false;
	}

    void Update ()
    {
        if (Input.GetKey(KeyCode.Space) && health == 0)
        {
            Time.timeScale = 1f;
            health = 3; 
            Application.LoadLevel(0);
        }

        if(health == 3)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
        }
        if (health == 2)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(false);
        }
        if (health == 1)
        {
            health1.SetActive(true);
            health2.SetActive(false);
            health3.SetActive(false);
        }
        if (health == 0)
        {
            health1.SetActive(false);
            health2.SetActive(false);
            health3.SetActive(false);
        }
        if (health <= 0)
        {
            YOUDIED.SetActive(true);
            Time.timeScale = 0.0f;
        }

        SCORE.text = "Score: " + score;

        transform.Translate(Vector2.right * power * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isFalling == false)
        {
            jumpOne = true;
            canDoubleJump = true;
            isFalling = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isFalling == true && canDoubleJump == true)
        {
            jumpTwo = true;
            canDoubleJump = false;
        }
    }
	
	void FixedUpdate ()
    {
        if (jumpOne == true)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
            jumpOne = false;
        }
        if (jumpTwo == true)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
            jumpTwo = false;
        }
	}

    void OnCollisionStay2D (Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            isFalling = false;
            canDoubleJump = false; 
        }

    }

    public void ScorePlus(int newScore)
    {
        score += newScore;
        if (score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", highScore);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Death")
        {
            health -= 1;
        }
    }
}
