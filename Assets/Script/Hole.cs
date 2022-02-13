using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public bool Explored = false;
    public enum HoleType
    {
        none,
        Water,
        Lava
    }
    public HoleType holeType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerHealth.instance.health > 0)
            {

                PlayerHealth.instance.takeDmg(10);
                PlayerMovement.instance.rb.velocity = Vector2.zero;
                PlayerMovement.instance.rb.AddForce(new Vector2(0f, 100));
                switch (holeType)
                {
                    case HoleType.Water:
                        StatsTracker.instance.addWater(1);
                        break;
                    case HoleType.Lava:
                        StatsTracker.instance.addLava(1);
                        break;
                    default:
                        break;
                }
            }

            Explored = true;
        }
    }
}
