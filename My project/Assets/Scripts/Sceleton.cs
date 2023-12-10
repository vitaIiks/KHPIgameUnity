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
            transform.Translate(Vector2.right * speed * Time.deltaTime); // ��� ������
            transform.localScale = new Vector2(1, 1); // ���� �������� ������
            if (transform.position.x >= RightPoint.position.x) // �������� �� ��������� ����� �����
            {
                movingRight = false; // ���� �������� ���� �����
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime); // ��� ����
            transform.localScale = new Vector2(-1, 1); // ���� �������� ����
            if (transform.position.x <= LeftPoint.position.x) // �������� �� ��������� ��� �����
            {
                movingRight = true; // ���� �������� ���� �������
            }
        }
    }

    private void Update()
    {
        Move();
    }
}


