using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class DestuctableTiles : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    public Tilemap destuctableTilemap;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        destuctableTilemap = GetComponent<Tilemap>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag ("bullet"))
        {
            audioSource.PlayOneShot(audioClip);
            Vector3 hitPosition = Vector3.zero;
        }
    }
}
