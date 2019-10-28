using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public GameObject effect;

    private Shake shake;

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("Screenshake").GetComponent<Shake>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

   void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);

            shake.CamShake();
            collision.GetComponent<Player>().health -= damage;
            Debug.Log(collision.GetComponent<Player>().health);
            Destroy(gameObject);
        }

   }

}
