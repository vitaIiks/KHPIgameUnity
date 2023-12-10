using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public Transform player;
    public Transform rotation;

    void Update()
    {
        if (player.localScale.x > 0)
        { 
            transform.localScale = new Vector3(1, 1, 1); 
        }
        else if (player.localScale.x < 0)
        { 
            transform.localScale = new Vector3(-1, 1, 1); 
        }
    }
}

