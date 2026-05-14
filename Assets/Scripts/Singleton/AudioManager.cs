using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private AudioSource secondaryMusicSource;

    [SerializeField] private float fadeDuration = 1.25f;

    private Coroutine currentFade;
    
    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip gameplayMusic;
    [SerializeField] private AudioClip gameOverMusic;
    [SerializeField] private AudioClip victoryMusic;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        DontDestroyOnLoad(gameObject);

        secondaryMusicSource = gameObject.AddComponent<AudioSource>();
        secondaryMusicSource.loop = true;
        secondaryMusicSource.playOnAwake = false;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "MainMenu":
                PlayMusic(mainMenuMusic);
                break;
            
            case "Gameplay":
                PlayMusic(gameplayMusic);
                break;
            
            case "GameOver":
                PlayMusic(gameOverMusic);
                break;
            
            case "Victory":
                PlayMusic(victoryMusic);
                break;
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip) return;

        if (currentFade != null)
        {
            StopCoroutine(currentFade);
        }

        currentFade = StartCoroutine(CrossfadeRoutine(clip));
    }

    IEnumerator CrossfadeRoutine(AudioClip newClip)
    {
        float originalVolume = musicSource.volume;
        
        secondaryMusicSource.clip = newClip;
        secondaryMusicSource.volume = 0;
        secondaryMusicSource.Play();

        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;

            float t = timer / fadeDuration;

            secondaryMusicSource.volume = Mathf.Lerp(0, originalVolume, t);
            musicSource.volume = Mathf.Lerp(originalVolume, 0, t);

            yield return null;
        }

        musicSource.Stop();

        secondaryMusicSource.volume = originalVolume;

        (musicSource, secondaryMusicSource) = (secondaryMusicSource, musicSource);

        currentFade = null;
    }

    public void StopMusic()
    {
     musicSource.Stop();   
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }


    public void StopSFX()
    {
        sfxSource.Stop();
    }
}
