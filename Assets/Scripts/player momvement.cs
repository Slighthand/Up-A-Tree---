using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    public AcornManager am;

    private Rigidbody2D myBody;
    private AudioSource audioSource;
    
    [SerializeField]
    private AudioClip jumpSound;

    private SpriteRenderer sr;
    private bool isGrounded;

    public LayerMask Ground;
    public Transform groundCheck;

    private bool hasJumped = false;
    private GameObject currentGround;

    private Animator anim;
    private string WALK_ANIMATION = "walk";

    [SerializeField]
    private float deathThreshold = -10f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


        sr = GetComponent<SpriteRenderer>();

        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().gravityScale = 5f;
    }

    // Update is called once per frame
        // Currently removed to prevent player from dying immediately upon entering game
   
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();


        //if (Input.GetButtonDown("Jump"))
        //    myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, Ground);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            hasJumped = true;
        }

        if (!isGrounded && hasJumped && currentGround != null)
        {
            Destroy(currentGround); // FIXED: Now works because it's a global variable!
            currentGround = null; // Reset so it doesn't try to destroy again
        }

        if (transform.position.y < deathThreshold)
        {
            Die();
        }

    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        // movementY = GetAxisRaw("Vertical");

        myBody.velocity = new Vector2(movementX * moveForce, myBody.velocity.y);


    }

    void Jump()
    {
        myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
        
        if (jumpSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    void AnimatePlayer()
    {

        if (movementX > 0)
        { anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else if (movementX < 0)
        { sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

   
   
    void Die()
        {
            Debug.Log("Player has fallen off the ground");
            gameObject.SetActive(false);
        // gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            hasJumped = false;
            currentGround = collision.gameObject; // FIXED: Now properly stores the ground!
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }

        void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Acorn"))
        {
            Destroy(other.gameObject);
            am.acornCount++;
        }
        if (other.tag == "Death") 
        {
            SceneManager.LoadScene("RestartMenu");
        }
    }

}



 