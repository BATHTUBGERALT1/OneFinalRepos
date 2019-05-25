using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// extra using statemet to allow us to use scene management functions
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour{
    //designer variables 

    //variable for the player speed
    public float speed;

    //variable for the jumping of the player
    public float jumpForce;

    //variable for the player movement
    private float moveInput;

    // variable for the players animator controller
    public Animator playerAnimator;

    //variable for sprite rendering
    public SpriteRenderer playerSprite;

    //variable for the players rigidbody
    private Rigidbody2D rb;

    //variable for players direction
    private bool facingRight = true;

    //variable for the player
    private int player;

    //variable for if it is on the ground
    private bool isGrounded;

    //variable for checking for ground
    public Transform groundCheck;

    // variable for the radius of check ground 
    public float checkRadius;

    // a mask calling ground layer
    public LayerMask whatIsGround;

    //variable for additional jumps
    private int extraJumps;

    // variable for how many additional jumps 
    public int extraJumpsValue;

    //setting the score
    public int ScoreToSet;

    // a gamemaster for the checkpoints
    private GameMaster gm;

    //checks if the checkpoint has been made
    public bool ifMadeCheckpoint = false;


    //checks for current level
    private Scene currentLevel;

    // checks which checkpoint to go to 
    private int CheckPointSwitch = 0;

    //variable to reference to the lives display
    public LifeScript livesObject;

    // boulders object
    public GameObject[] Boulders;

    // invisible walls object
    public GameObject[] InvWalls;

    // for adding audio to player death
    public AudioSource Death;

    // checks what the last score was 
    public int theLastScore;


    public void Start()
    {


        // checks and saves on collision between checkpoints

        ScoreToSet = PlayerPrefs.GetInt("CheckScore", 0);
        PlayerPrefs.SetInt("score", ScoreToSet);
        PlayerPrefs.Save();

        //saves upon collision wiht checkpoints 

        PlayerPrefs.SetInt("CheckPointHit", 0);
        PlayerPrefs.Save();

        // gives player amount of jumps per inputted value

        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

        //finds the tagged object, and turns off collision with player and movinginvwalls

        InvWalls = GameObject.FindGameObjectsWithTag("MovingInvWalls");
        foreach (GameObject InvWall in InvWalls)
        {
            //ignores collision with the invisible walls
            Physics2D.IgnoreCollision(InvWall.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        }

    }


    public void FixedUpdate()
    {


        //checks if the checkpoint has been his or not
        CheckPointSwitch = PlayerPrefs.GetInt("CheckPointHit", 0);
        if (CheckPointSwitch == 1)
        {
            ifMadeCheckpoint = true;
        }
        else
        {
            ifMadeCheckpoint = false;
        }


        //for the player jumping to see if it is in contact with ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //this is for sprite direction and speed 
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


        //if the player is facing right stay right, left stay left
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }

        //calls the animator float walk into action
        playerAnimator.SetFloat("Walk", Mathf.Abs(moveInput));
    }


    //this calls the direction into action and sets the flip
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

    public void Update()
    {

        //if grounded is true then it will give jumps equal to those given, so that it cant constantly
        //reset and is only available to that number of jumps
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

        //taken oout saving of lives as it now serves as a death counter and isnt needed to save between levels
        //livesObject.SaveLives();

        //plays death sound on the kill of player 
        Death.Play();

        //checks if its game over
        bool gameOver = livesObject.isGameOver();

        //if lives are = 0 go to game over screen however this will never be called due to lives being converted to a death counter 
        if (gameOver == true)
        {
            //if game is over load game over
            SceneManager.LoadScene("Game Over");

        }
        else
        {

            //gets the current scene/level and reloads
            Scene currentLevel = SceneManager.GetActiveScene();
            // if it isnt game over...
            // reset to beginning 

            //if the checkpoint isnt made then reset the level, however this doesnt save the scrolls and means that 
            //once collected once they are permanently gone until the game fully resets
            if (ifMadeCheckpoint == false)
            {

                SceneManager.LoadScene(currentLevel.buildIndex);

            }
            else
            {

                //checks for boulders & invwalls tagged with other and resets them to their original position within the level
                // this could be reset however i felt that with the death counter 
                // a constant resetting of scrolls would be unneccessary and the player could focus on traversing the level as 
                //opposed to focusing on score solely

                Boulders = GameObject.FindGameObjectsWithTag("Other");

                foreach (GameObject Boulder in Boulders)
                {
                    Boulder.GetComponent<Boulder_Script>().ResetSelf();
                }

                InvWalls = GameObject.FindGameObjectsWithTag("MovingInvWalls");

                foreach (GameObject InvWall in InvWalls)
                {
                    Physics2D.IgnoreCollision(InvWall.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                    InvWall.GetComponent<InvWalls>().ResetSelf();
                }


                //saves score when the player dies
                ScoreToSet = PlayerPrefs.GetInt("CheckScore", 0);
                PlayerPrefs.SetInt("score", ScoreToSet);
                PlayerPrefs.Save();

                //sets the player position to the last checkpoint with the tag of GM 
                gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
                transform.position = gm.lastCheckPointPos;
            }
        }
    }

}

 





