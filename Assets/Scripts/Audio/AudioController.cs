using UnityEngine;


public class AudioController : MonoBehaviour
{
    [Header("------------Audio Source------------")]
    [SerializeField] AudioSource musicSource; // audio source component 
    //[SerializeField] AudioSource SFXSource;

    [Header("------------Audio Clip------------")]
    public AudioClip background;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

}
