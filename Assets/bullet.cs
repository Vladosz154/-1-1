using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject hit;
    
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(hit, transform.position, transform.rotation);
        Destroy(gameObject);

    }
    
    
}
