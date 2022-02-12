using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scène");
            return;
        }
        instance = this;
    }

       
    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos, AudioMixerGroup mixer)
    {
        GameObject tmp = new GameObject("tempAudio");
        tmp.transform.position = pos;
        AudioSource audioSource = tmp.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = mixer;
        audioSource.Play();
        Destroy(tmp, clip.length);
        return audioSource;
    }
}
