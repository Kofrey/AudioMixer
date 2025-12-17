using UnityEngine;

public class AudioPlayer : MonoBehaviour
{ 
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;

    public void Play()
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}
