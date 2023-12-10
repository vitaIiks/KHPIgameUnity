using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
   
    public int maxHelth = 100;
    int currentHelth;

    private void Start()
    {
        currentHelth = maxHelth;
    }


    public void TakeDamge(int damage)
    {
        currentHelth -= damage;
        
        if (currentHelth <= 0)
        {
            Die();
        }
    }


    public virtual void Die()
    {
        
        Destroy(this.gameObject);
    }
}
