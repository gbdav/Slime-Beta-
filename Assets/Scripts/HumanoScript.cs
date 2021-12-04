using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoScript : MonoBehaviour
{
    public Transform Slime;
    private Animator animator;
    public GameObject RocaPrefab;

    public int maxHealth = 100;
    int currentHealth;

    private float LastShoot;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Slime == null) return;

        Vector3 direction = Slime.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Slime.position.x - transform.position.x);

        if (distance < 7.0f && Time.time > LastShoot + 1.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        //Debug.Log("Shotting ");
        Vector3 direction = new Vector3(transform.localScale.x, 0.5f, 0.0f);
        GameObject roca = Instantiate(RocaPrefab, transform.position + direction, Quaternion.identity);
        roca.GetComponent<RocaScript>().SetDirection(new Vector3(transform.localScale.x, 0.0f, 0.0f));
    }


    public void TakeDmage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        } else
        {
            // Play hurt anumation
            animator.SetTrigger("hurt");
        }

    }

    void Die()
    {
        Debug.Log("Enemy died");
        // Die animation
        animator.SetBool("isDead", true);

        // Disable the enemy
        // GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
