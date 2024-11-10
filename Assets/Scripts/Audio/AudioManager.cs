using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource misicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("--- Music ---")]
    public AudioClip BGMusic;
    public AudioClip menuMusic;
    public AudioClip Level1Music;
    public AudioClip VictoryMusic;
    public AudioClip LoseMusic;

    [Header("--- SFX ---")]
    [Header("- Player -")]
    public AudioClip FrontAttack;
    public AudioClip Hurt;
    public AudioClip Jump;
    public AudioClip PickUp;
    public AudioClip Walk;
    public AudioClip Run;

    [Header("- Enemy -")]
    public AudioClip EnFrontAttack;
    public AudioClip EnHurt;

    private float _colapsTimer = 0;

    private void Start()
    {
        misicSource.clip = BGMusic;
        misicSource.Play();
    }

    private void Update()
    {
        _colapsTimer -= Time.deltaTime;
    }

    public void PlayMusic(AudioClip clip)
    {
        misicSource.clip = clip;
        misicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayColapsSFX(AudioClip clip)
    {
        if (_colapsTimer < 0)
        {
            SFXSource.PlayOneShot(clip);
            _colapsTimer = clip.length;
        }
    }
}
