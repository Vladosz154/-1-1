using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed;
    public Transform player;
    private Vector2 target;
    private Rigidbody2D rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target = (player.position - transform.position) / (player.position - transform.position).magnitude;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.AddForce(target * speed, ForceMode2D.Impulse);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }
}