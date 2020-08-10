using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{

    public Sprite flagClosed;
    public Sprite flagOpen;
    private SpriteRenderer spriteRenderer;


    public bool checkPointActive = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();                // we got the sprite renderer;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            this.spriteRenderer.sprite = this.flagOpen;
            checkPointActive = true;
        }
    }
}
