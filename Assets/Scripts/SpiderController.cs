using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{

    public float moveSpeed;
    private bool canMove;
    private Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
          
        }
    }


    private void OnBecameVisible()
    {
        canMove = true;
    }
    //private void OnBecameInvisible()
    //{
    //    canMove = false;
    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("killPlane")) {
            Destroy(gameObject);
        }
    }
}

