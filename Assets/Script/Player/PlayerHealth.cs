using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;

    public int health = 3;
    public bool invicible = false;
    public HealthBar hpBar;

    public Transform Checkpoint;

    public AudioSource hitSound;

    public static PlayerHealth instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la sc�ne");
            return;
        }
        instance = this;
    }

    void Update()
    {
        animator.SetBool("isDead", health <= 0);
        hpBar.health = health;
    }
    public void takeDmg(int amount)
    {
        if (invicible)
        {
            return;
        }
        StatsTracker.instance.dodge = 0;
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
            AudioManager.instance.PlayClipAt(hitSound.clip, transform.position, hitSound.outputAudioMixerGroup);
            // frame invincibility
        }
        else
        {
            AudioManager.instance.PlayClipAt(hitSound.clip, transform.position, hitSound.outputAudioMixerGroup);
            Die();
        }
    }
    public void heal(int amount)
    {
        health += amount;
        if (health > 3)
            health = 3;
    }

    public void Die()
    {
        // launch respawn
        StatsTracker.instance.addDeath(1);
        StartCoroutine(RespawnDelay());
    }

    public IEnumerator InvicibilityDelay()
    {
        yield return new WaitForSeconds(0.5f);
        invicible = false;
        animator.SetBool("isDmg", false);
    }

    public void respawn()
    {
        transform.position = Checkpoint.position;
        health = 3;
    }

    public IEnumerator RespawnDelay()
    {
        yield return new WaitForSeconds(0.8f);
        respawn();
    }
}