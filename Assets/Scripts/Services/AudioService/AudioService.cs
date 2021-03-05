using UnityEngine;

public sealed class AudioService : Service
{
    private readonly SoundData _data;

    private AudioClip _soundClip;
    private AudioClip _musicClip;
    private AudioSource _soundSource;
    private AudioSource _musicSource;

    private float _volumeSound;
    private float _volumeMusic;

    public AudioService()
    {
        _data = Data.Instance.SoundData;
        LoadSettings();
        SetAudioSource();
    }

    private void SetAudioSource()
    {
        if (_soundSource != null) return;
        else
        {
            var sound = new GameObject("SoundManager");
            _soundSource = sound.AddComponent<AudioSource>();
            _soundSource.outputAudioMixerGroup = _data.soundAudioMixerGroup;
            _soundSource.volume = GetSoundVolume();
            Object.DontDestroyOnLoad(sound);
        }

        if (_musicSource != null) return;
        else
        {
            var music = new GameObject("MusicManager");
            _musicSource = music.AddComponent<AudioSource>();
            _musicSource.outputAudioMixerGroup = _data.musicAudioMixerGroup;
            _musicSource.volume = GetMusicVolume();
            Object.DontDestroyOnLoad(music);
        }
    }

    public void PlaySound(string audio)
    {
        if (_soundClip != null)
        {
            _soundClip.UnloadAudioData();
        }
        _soundClip = CustomResources.Load<AudioClip>(audio);
        _soundSource.PlayOneShot(_soundClip);
    }

    public void PlayMusic(string audio)
    {
        if (_musicClip != null)
        {
            _musicClip.UnloadAudioData();
        }
        _musicClip = CustomResources.Load<AudioClip>(audio);
        _musicSource.PlayOneShot(_musicClip);
    }

    public void PauseMusic()
    {
        _musicSource.Pause();
    }

    public void UnPauseMusic()
    {
        _musicSource.UnPause();
    }

    public void SetVolume(float value)
    {
        _soundSource.volume = value;
        _musicSource.volume = value;
        SetSoundVolume(value);
        SetMusicVolume(value);
    }

    private void SaveSettings()
    {
        CustomPlayerPrefs.SetFloat("SoundVolume", _volumeSound);
        CustomPlayerPrefs.SetFloat("MusicVolume", _volumeMusic);
    }

    private void LoadSettings()
    {
        _volumeSound = CustomPlayerPrefs.GetFloat("SoundVolume");
        _volumeMusic = CustomPlayerPrefs.GetFloat("MusicVolume");
    }

    private void SetMusicVolume(float value)
    {
        _volumeMusic = value;
        SaveSettings();
    }

    private float GetMusicVolume()
    {
        return _volumeMusic;
    }

    private void SetSoundVolume(float value)
    {
        _volumeSound = value;
        SaveSettings();
    }

    private float GetSoundVolume()
    {
        return _volumeSound;
    }

    public bool SoundIsPlaying()
    {
        if (Mathf.Approximately(_volumeSound, 0f) && Mathf.Approximately(_volumeMusic, 0f))
        {
            return false;
        }
        else return true;
    }
}