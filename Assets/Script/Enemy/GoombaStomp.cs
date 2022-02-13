using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaStomp : MonoBehaviour
{
    public enum EnemyType
    {
        None,
        Ground,
        Fly,
        Boss
    }
    public GameObject toDestroy;
    public EnemyType eType;
    public AnimationClip deathClip;
    public Animator animator;
    public Waypoints waypointScript;
    public AudioSource audioSource;
    public AudioSource audioHurt;

    public int health;
    private bool invicible;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement.instance.rb.velocity = new Vector2(PlayerMovement.instance.rb.velocity.x, 0);
            PlayerMovement.instance.rb.AddForce(new Vector2(0f, 350));
            TakeDmg();
        }
    }

    private void TakeDmg()
    {
        if (invicible)
            return;
        health -= 1;
        if (health > 0)
        {
            invicible = true;
            animator.SetBool("isDmg", true);
            waypointScript.enabled = false;
            audioHurt.Play();
            StartCoroutine(InvicibilityDelay());
        } else
        {
            Die();

            switch (eType)
            {
                case EnemyType.Ground:
                    StatsTracker.instance.addGKill(1);
                    break;
                case EnemyType.Fly:
                    StatsTracker.instance.addGKill(1);
                    break;
                case EnemyType.Boss:
                    print("Boss");
                    break;
                default:
                    break;
            }
        }
    }

    private void Die()
    {
        animator.SetBool("isDead", true);
        audioSource.Play();
        StartCoroutine(DeathDelay());
        waypointScript.enabled = false;
        transform.parent.GetComponent<BoxCollider2D>().enabled = false;
        transform.GetComponent<BoxCollider2D>().enabled = false;
    }
    private IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(deathClip.length);
        Destroy(toDestroy);
    }

    public IEnumerator InvicibilityDelay()
    {
        yield return new WaitForSeconds(0.75f);
        invicible = false;
        animator.SetBool("isDmg", false);
        waypointScript.enabled = true;
    }
}
