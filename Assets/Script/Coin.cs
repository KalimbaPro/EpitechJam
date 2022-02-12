using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public AudioSource pickSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StatsTracker.instance.addCoin(1);
            AudioManager.instance.PlayClipAt(pickSound.clip, transform.position, pickSound.outputAudioMixerGroup);
            Destroy(gameObject);
        }
    }
}
