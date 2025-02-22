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
    private float movementY;


    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "walk";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        if (Input.GetButtonDown("Jump"))
            myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);


    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        myBody.velocity = new Vector2(movementX * moveForce, movementY * moveForce);
        //transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    

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

        if (movementY > 0)
        {
            sr.flipY = false;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else if (movementY < 0)
        {
            sr.flipY = true;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
   
    }



}

 