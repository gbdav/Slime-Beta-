using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocaScript : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        // Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SlimeMovement slime = other.GetComponent<SlimeMovement>();
        if (slime != null)
        {
            slime.Hit();
        }
        DestroyBullet();
    }
}
