using UnityEngine;
[AddComponentMenu("TienCuong/AudioManager")]
public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource MusicSource;
    public AudioSource sfxEnemySource;
    [Header("Audio clip")]
    public AudioClip backgroundMusic;
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get => instance;
    }
    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
    }
    void Start()
    {
        PlayBackGroundMusic();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayBackGroundMusic()
    {
        MusicSource.clip = backgroundMusic;
        MusicSource.Play();
        MusicSource.loop = true;
    }

    public void PlayEnemySfxMusic(AudioClip clip)
    {
        sfxEnemySource.PlayOneShot(clip);
    }

    public void SetMusicVolume(float volume)
    {
        MusicSource.volume = volume;
    }
}
