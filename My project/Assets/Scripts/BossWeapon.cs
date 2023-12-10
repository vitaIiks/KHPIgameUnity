using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage = 50;

    public Vector3 attackOffset;
    public float attackRange = 3f;
    public LayerMask attackMAsk;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colinfo = Physics2D.OverlapCircle(pos, attackRange, attackMAsk);
        if(colinfo != null )
        {
            colinfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }

    }
}
