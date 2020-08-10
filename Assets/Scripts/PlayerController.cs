using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float moveSpeed;
    private float jumpHeight;
    private Rigidbody2D myRigidBody;

    public Transform groundCheck; // check if we are on the ground
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator animator;

    public Vector3 responPosition;

    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5;
        jumpHeight = 12;
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        responPosition = transform.position;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

                       // check if we are on ground layer :xyz pos, the radius, the actual layer
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            // <0 left, >0 right
            myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f); // y stays the same, z doesnt matter.
            transform.localScale = new Vector3(1f, 1f, 1f);                      //transform on this specific object 
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {

            myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else {
            myRigidBody.velocity = new Vector3(0f, myRigidBody.velocity.y, 0f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded == true) {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpHeight, 0f);
                }

        animator.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));
        animator.SetBool("Grounded", isGrounded);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("killPlane"))
        {   
            levelManager.Respawn();
        }
        else if (other.CompareTag("checkPoint"))
        {
            responPosition = other.transform.position;
        } 
    }
    private void OnCollisionEnter2D(Collision2D collision) // whenever player collide with other object
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform") {
            transform.parent = null;
        }
    }

}
