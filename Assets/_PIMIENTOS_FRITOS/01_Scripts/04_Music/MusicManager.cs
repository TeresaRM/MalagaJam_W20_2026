using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [Header("Audio")]
    [SerializeField] private AudioSource musicSource;

    [Header("Music Profiles")]
    [SerializeField] private List<MusicProfile> musicProfiles;

    private MusicProfile currentProfile;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        EnsureAudioSource();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        EnsureAudioSystemActive();
        UpdateMusicForScene(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        EnsureAudioSystemActive();
        UpdateMusicForScene(scene.name);
    }

    void UpdateMusicForScene(string sceneName)
    {
        foreach (var profile in musicProfiles)
        {
            if (profile.allowedScenes.Contains(sceneName))
            {
                SwitchToProfile(profile);
                return;
            }
        }

        StopMusic();
        currentProfile = null;
    }

    void SwitchToProfile(MusicProfile newProfile)
    {
        if (currentProfile == newProfile)
            return;

        bool shouldRestart = newProfile.restartOnSwitch || musicSource.clip != newProfile.musicClip;

        currentProfile = newProfile;

        musicSource.clip = newProfile.musicClip;
        musicSource.volume = newProfile.volume;
        musicSource.loop = true;

        if (shouldRestart || !musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    void StopMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Stop();
    }

    void EnsureAudioSystemActive()
    {
        EnsureAudioListener();
        EnsureAudioSourceActive();
    }

    void EnsureAudioListener()
    {
        AudioListener listener = FindAnyObjectByType<AudioListener>();

        if (listener == null)
        {
            Camera cam = Camera.main;
            if (cam != null)
                listener = cam.gameObject.AddComponent<AudioListener>();
            else
                listener = new GameObject("AudioListener").AddComponent<AudioListener>();
        }

        listener.enabled = true;
    }

    void EnsureAudioSourceActive()
    {
        if (musicSource == null)
            EnsureAudioSource();

        musicSource.enabled = true;
    }

    void EnsureAudioSource()
    {
        musicSource = GetComponent<AudioSource>();
        if (musicSource == null)
            musicSource = gameObject.AddComponent<AudioSource>();
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
