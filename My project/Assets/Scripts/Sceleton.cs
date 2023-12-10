using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class Sceleton : Entity
{
    public float speed = 2.0f; 
    public Transform LeftPoint; 
    public Transform RightPoint;
    private bool movingRight = true;
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    private void Move()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); // рух вправо
            transform.localScale = new Vector2(1, 1); // зм≥на напр€мку вправо
            if (transform.position.x >= RightPoint.position.x) // перев≥рка чи дос€гнута права точка
            {
                movingRight = false; // зм≥на напр€мку руху нал≥во
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime); // рух вл≥во
            transform.localScale = new Vector2(-1, 1); // зм≥на напр€мку вл≥во
            if (transform.position.x <= LeftPoint.position.x) // перев≥рка чи дос€гнута л≥ва точка
            {
                movingRight = true; // зм≥на напр€мку руху направо
            }
        }
    }

    private void Update()
    {
        Move();
    }
}


