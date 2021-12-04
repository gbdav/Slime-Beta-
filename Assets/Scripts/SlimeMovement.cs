using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlimeMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator animator;
    private float Horizontal;
    private bool Grounded;

    // Atack
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 35;

    public int vidas;
    public Image[] lives;

    // enemies
    public LayerMask enemyLayers;

    public GameObject RocaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Lost
        if (transform.position.y < -10.0f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SinVidas");
        }
        // Movimiento
        Horizontal = Input.GetAxisRaw("Horizontal");

        // Ataque
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-3.0f, 3.0f, 3.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);

        animator.SetBool("running", Horizontal != 0.0f);

        // Detectar Suelo
        Debug.DrawRay(transform.position, Vector3.down * 0.4f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.6f))
        {
            Grounded = true;
        }
        else Grounded = false;

        // Salto
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && Grounded)
        {
            Jump();
        }

    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Attack()
    {
        // animation
        animator.SetTrigger("attack");
        // detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        // damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<HumanoScript>().TakeDmage(attackDamage);
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void Hit()
    {
        vidas--;
        lives[vidas].enabled = false;

        if (vidas == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SinVidas");
        }

    }

}
