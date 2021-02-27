using UnityEngine;

public sealed class AudioService : Service
{
    private readonly SoundData _data;
    private AudioClip _audioClip;
    private AudioSource _soundAudioSource;
    private AudioSource _musicAudioSource;

    public AudioService()
    {
        _data = Data.Instance.SoundData;
        SetAudioSource();
    }

    private void SetAudioSource()
    {
        if (_soundAudioSource != null) return;
        else
        {
            var sound = new GameObject("SoundManager");
            _soundAudioSource = sound.AddComponent<AudioSource>();
            _soundAudioSource.outputAudioMixerGroup = _data.soundAudioMixerGroup;
            Object.DontDestroyOnLoad(sound);
        }

        if (_musicAudioSource != null) return;
        else
        {
            var music = new GameObject("MusicManager");
            _musicAudioSource = music.AddComponent<AudioSource>();
            _musicAudioSource.outputAudioMixerGroup = _data.musicAudioMixerGroup;
            Object.DontDestroyOnLoad(music);
        }
    }

    public void PlaySound(string audio)
    {
        _audioClip = CustomResources.Load<AudioClip>(audio);
        _soundAudioSource.PlayOneShot(_audioClip);
    }

    public void PlayMusic(string audio)
    {
        _audioClip = CustomResources.Load<AudioClip>(audio);
        _musicAudioSource.PlayOneShot(_audioClip);
    }

    public void StopMusic()
    {
        _musicAudioSource.Stop();
    }

    public void PauseMusic()
    {
        _musicAudioSource.Pause();
    }

    public void UnPauseMusic()
    {
        _musicAudioSource.UnPause();
    }
}