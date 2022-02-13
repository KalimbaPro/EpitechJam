using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public bool Explored = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerHealth.instance.health > 0)
            {
                PlayerHealth.instance.takeDmg(10);
                PlayerMovement.instance.rb.velocity = Vector2.zero;
                PlayerMovement.instance.rb.AddForce(new Vector2(0f, 300));
            }

            Explored = true;
        }
    }
}
