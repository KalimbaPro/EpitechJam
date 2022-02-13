using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDmg : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.takeDmg(1);
            PlayerMovement.instance.SetHorizontalMovement(0);
        }
    }
}
