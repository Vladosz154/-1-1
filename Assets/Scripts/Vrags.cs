using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Vrags : MonoBehaviour
{
    public int health ;
    public GameObject hit;
    private UnityEngine.Object VragsRef;
    Vector3 spawnPos;
    public float speed;
    public float retreatDistance;
    private float timeBtwShoots;
    public float startBtwShoots;
    public GameObject bullet;
    public Transform fire;
    private Rigidbody2D bot;
    public Transform target;
    private NavMeshAgent agent;
    public string collisionTag;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        spawnPos = transform.position;
        VragsRef = Resources.Load("Vrag");
        timeBtwShoots = startBtwShoots;
        bot = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.SetDestination(target.position);
        var direction = target.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (Vector2.Distance(transform.position, target.position) > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) < 1 && (Vector2.Distance(transform.position, target.position) > retreatDistance))
        {
            transform.position = this.transform.position; 
        }
        else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        if (timeBtwShoots <= 0)
        {
            Instantiate(bullet, fire.position,Quaternion.identity);
            timeBtwShoots = startBtwShoots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
    public void Respawn()
    {
        GameObject vraqsCopy = (GameObject)Instantiate(VragsRef);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == collisionTag)
        {
            health -= 1;
            if (health == 0)
            {  
                VragsCount.vrags += 1;
                Invoke("Respawn", 1f);
                gameObject.SetActive(false);
            }
        }
    }
}
