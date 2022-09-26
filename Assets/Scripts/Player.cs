using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public GameObject hit;
    public float speed = 1f;
    private Vector2 direction;
    public Animator anim;
    private Rigidbody2D rb;
    public Camera camera;
    Vector2 mouse;
    private UnityEngine.Object PlayerRef;
    Vector3 spawnPos;
    public string collisionTag;
    public Transform fire;
    public GameObject bullet;
    public float bulletForce = 20f;
    public float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject player; 
    [SerializeField] GameObject Text;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPos = transform.position;
        PlayerRef = Resources.Load("Player");
        Text.SetActive(false);
    }
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        mouse = camera.ScreenToWorldPoint(Input.mousePosition);
        if (timeBtwShots >= 0)
        {
            timeBtwShots -= Time.deltaTime;
        }
        if (timeBtwShots <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                Shoot();
                Text.SetActive(true);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                Text.SetActive(false);
            } 
        }
    }
    void Shoot()
    {
        GameObject bullets = Instantiate(bullet, fire.position, fire.rotation);
        Rigidbody2D rb = bullets.GetComponent<Rigidbody2D>();
        rb.AddForce(fire.up * bulletForce, ForceMode2D.Impulse);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        Vector2 lookDir = mouse - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    public void Respawn()
    {
        GameObject playerCopy = (GameObject)Instantiate(PlayerRef);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == collisionTag)
        {
            health -= 1;
            if (health == 0)
            {
                PlayerCount.player += 1;
                Invoke("Respawn", 1f);
                if (Input.GetButtonDown("Fire1"))
                {
                    Text.SetActive(true);
                }
                else
                {
                    Text.SetActive(false);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
