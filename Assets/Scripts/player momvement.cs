using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;
    private bool hasJumped = false;



    private Rigidbody2D myBody;

    private SpriteRenderer sr;
    private bool isGrounded;

    public LayerMask Ground;
    public Transform groundCheck;

    private Animator anim;
    private string WALK_ANIMATION = "walk";

    [SerializeField]
    private float deathThreshold = -10f;
    private GameObject currentGround;

    public AcornManager am;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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
            Destroy(currentGround);
            currentGround = null;
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
    }

    void AnimatePlayer()
    {

        if (movementX > 0)
        { anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        { sr.flipX = true;
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
        }


  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            hasJumped = false;
            currentGround = collision.gameObject;
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
    }
}



 