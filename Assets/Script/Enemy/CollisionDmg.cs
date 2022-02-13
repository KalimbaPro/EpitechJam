using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDmg : MonoBehaviour
{
    public int dmg;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.takeDmg(dmg);
            // PlayerMovement.instance.SetHorizontalMovement(0);
            PlayerMovement.instance.rb.velocity = Vector2.zero;
        }
    }
}
