using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public int heal;
    public bool golden;
    public AudioSource pickSound;
    public SpriteRenderer sr;
    public Sprite goldenSprite;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 8);
        golden = Random.Range(0, 100) == 0;

        if (golden)
        {
            sr.sprite = goldenSprite;
        }
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
