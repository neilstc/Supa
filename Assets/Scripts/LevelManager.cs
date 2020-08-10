using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public float waitToResponed;
    public PlayerController player;
    public GameObject deathExplotion;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCo");
    }
    public IEnumerator RespawnCo() {

        player.gameObject.SetActive(false);
        Instantiate(deathExplotion, player.transform.position, player.transform.rotation);  // creating an object where ever you tell it
        yield return new WaitForSeconds(waitToResponed);
        player.transform.position = player.responPosition;
        player.gameObject.SetActive(true);
    }
}
