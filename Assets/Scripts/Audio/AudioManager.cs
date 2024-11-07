using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource misicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("--- Music ---")]
    public AudioClip menuMusic;
    public AudioClip Level1Music;

    [Header("--- SFX ---")]
    [Header("- Player -")]
    public AudioClip FrontAttack;
    public AudioClip Hurt;
    public AudioClip Jump;
    public AudioClip PickUp;
    public AudioClip Walk;

    [Header("- Enemy -")]
    public AudioClip EnFrontAttack;
    public AudioClip EnHurt;

    private void Start()
    {
        misicSource.clip = Level1Music;
        misicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
