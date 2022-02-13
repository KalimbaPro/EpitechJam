using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;

    public int health = 3;
    public bool invicible = false;
    public HealthBar hpBar;

    public static PlayerHealth instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            takeDmg(1);
        }
        animator.SetBool("isDead", health <= 0);
        hpBar.health = health;
    }
    public void takeDmg(int amount)
    {
        if (invicible)
        {
            return;
        }
        health -= amount;
        if (health < 0)
        {
            health = 0;
        }
        if (health > 0)
        {
            animator.SetBool("isDmg", true);
            invicible = true;
            StartCoroutine(InvicibilityDelay());
            // frame invincibility
        } else
        {
            Die();
        }
    }
    public void heal(int amount)
    {
        health += amount;
        if (health > 3)
            health = 33;
    }

    public void Die()
    {
        // launch respawn
    }

    public IEnumerator InvicibilityDelay()
    {
        yield return new WaitForSeconds(0.5f);
        invicible = false;
        animator.SetBool("isDmg", false);
    }
}