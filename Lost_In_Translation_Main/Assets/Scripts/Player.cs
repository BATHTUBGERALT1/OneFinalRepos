using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// extra using statemet to allow us to use scene management functions
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;

    private Rigidbody2D rb;

    private bool facingRight = true;


    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    private int extraJumps;
    public int extraJumpsValue;

    public int ScoreToSet;

    private GameMaster gm;

    public bool ifMadeCheckpoint = false;

    private Scene currentLevel;

    private int CheckPointSwitch = 0;
    //variable to reference to the lives display
    public LifeScript livesObject;

    private void Start()
    {
        PlayerPrefs.SetInt("CheckPointHit", 0);
        PlayerPrefs.Save();

        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {

        CheckPointSwitch = PlayerPrefs.GetInt("CheckPointHit", 0);
        if (CheckPointSwitch == 1)
        {
            ifMadeCheckpoint = true;
        }
        else
        {
            ifMadeCheckpoint = false;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }

        playerAnimator.SetFloat("Walk", Mathf.Abs(moveInput));
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

    private void Update()
    {
        if(isGrounded == true)
        {

            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;

        }
    }
    //this is for dealing with the players death
    public void Kill()
    {
        //takes away lives and saves the changes made
        livesObject.LoseLife();
        livesObject.SaveLives();

        //checks if its game over
        bool gameOver = livesObject.isGameOver();


        if (gameOver == true)
        {
            //if game is over load game over
            SceneManager.LoadScene("Game Over");

        }
        else
        {

            Scene currentLevel = SceneManager.GetActiveScene();
            // if it isnt game over...
            // reset to beginning 
            if (ifMadeCheckpoint == false)
            {

                SceneManager.LoadScene(currentLevel.buildIndex);

            }
            else
            {

                //check current level



                ScoreToSet = PlayerPrefs.GetInt("CheckScore", 0);
                PlayerPrefs.SetInt("score", ScoreToSet);
                PlayerPrefs.Save();

                gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
                transform.position = gm.lastCheckPointPos;
            }
        }
    }

}

 





