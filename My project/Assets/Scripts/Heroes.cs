using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Heroes : Entity
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForse = 15f;

    private bool isGrounded = false; 
    public int attacDamage = 40;
    public float attacRange = 0.5f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public Transform attacPoint;

    
    public LayerMask enemyLayers;
    public static Heroes instance { get; set; }


    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        instance = this;
    }

    private void FixedUpdate()
    {
        CheckGround();
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attac();
        }
        if (isGrounded)
        {
            State = States.ldle;
        }
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }


    void Attac()
    {
        anim.SetTrigger("Attac");
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attacPoint.position, attacRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemys)
        {
            enemy.GetComponent<Entity>().TakeDamge(attacDamage);
        }
    }


    void OnDrawGizmosSelected()
    {
        if(attacPoint == null)
        {
            return;
        }
        Gizmos.DrawSphere(attacPoint.position, attacRange);

    }


    private void Run()
    {
        if (isGrounded)
        {
            State = States.run;
        }
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }


    private void Jump()
    {
        rb.AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;

        if (!isGrounded)
        {
            State = States.jump;
        }
    }

    
}

public enum States
{
    ldle,
    run,
    jump,
}
