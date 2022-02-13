using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public int heal;
    public bool golden;
    public AudioSource pickSound;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 8);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.heal(heal);
            StatsTracker.instance.addApple(1);
            AudioManager.instance.PlayClipAt(pickSound.clip, transform.position, pickSound.outputAudioMixerGroup);
            Destroy(gameObject);
        }
    }
}
