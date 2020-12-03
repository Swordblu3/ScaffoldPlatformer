using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggs : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    private PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        target = new Vector2(player.position.x, player.position.y);
        health = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if ((transform.position.x == target.x) && (transform.position.y == target.y))
        {
            DestroyProjectile();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
