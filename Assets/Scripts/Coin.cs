using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().score++;
            FindObjectOfType<CoinManager>().coinsSpawned--;
            Debug.Log(collision.GetComponent<Player>().score);
            Destroy(gameObject);
        }
    }
}
