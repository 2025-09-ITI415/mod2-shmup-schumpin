using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager S;

    private AudioSource audioSource;

    void Awake()
    {
        S = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
