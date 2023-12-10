using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public bool isflipped = false;

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        

        if (transform.position.x > player.position.x && isflipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180, 0f);
            isflipped = false;
        }
        else if (transform.position.x < player.position.x && !isflipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isflipped = true;
        }
    }
}
