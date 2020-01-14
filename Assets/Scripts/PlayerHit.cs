using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("breakable"))
        {
            other.GetComponent<Pot>().Smash();
        }
        if (other.CompareTag("Rock"))
        { 
            player.GetComponent<Player>().Stones += other.GetComponent<Ressource>().Smash();  
        }
        if (other.CompareTag("Wood"))
        {
            player.GetComponent<Player>().Woods += other.GetComponent<Ressource>().Smash();
        }
    }
}
