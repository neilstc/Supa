using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{

    public float waitToResponed;
    public PlayerController player;
    public GameObject deathExplotion;

    //coins 
    public Text coinsCollected;
    public int coinCount = 0;

    //hearts
    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;


    public int maxHealth = 6;
    public int currentHealth;



    bool respawning; 
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        coinsCollected.text = "Coins: " + this.coinCount;
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && !respawning) {
            Respawn();
            respawning = true;
        }
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCo");
    }
    public IEnumerator RespawnCo() {

        player.gameObject.SetActive(false);
        Instantiate(deathExplotion, player.transform.position, player.transform.rotation);  // creating an object where ever you tell it
        yield return new WaitForSeconds(waitToResponed);
        currentHealth = maxHealth;
        respawning = false;
        player.transform.position = player.responPosition;
        player.gameObject.SetActive(true);
    }

    public void addCoins(int coinsToAdd) {
        this.coinCount += coinsToAdd;
        coinsCollected.text = "Coins: " + this.coinCount;
    }
    public void HurtPlayer(int damageTaken) {
        this.currentHealth -= damageTaken;
    }
}
