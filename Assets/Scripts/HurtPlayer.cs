﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    LevelManager levelManager;
    public int damageHit = 2;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            levelManager.HurtPlayer(damageHit);
            if (levelManager.currentHealth == 0)
            {
                levelManager.Respawn();
            }

        }
    }
}
