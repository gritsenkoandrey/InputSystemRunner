using UnityEngine;
using UnityEngine.UI;

public sealed class MainMenuBehaviour : BaseUI
{
    [SerializeField] private Button _startButton = null;
    [SerializeField] private Button[] _volumeButton = null;
    [SerializeField] private Button _nextButton = null;
    [SerializeField] private Button _prevButton = null;

    private int _index = 0;
    private GameObject _haveCoins;
    private RawImage[] _images;


    private void Awake()
    {
        _haveCoins = GameObject.FindGameObjectWithTag(TagHelper.GetTag(TypeTag.HaveCoinUI));
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartButton);

        _volumeButton[0].onClick.AddListener(VolumeOff);
        _volumeButton[1].onClick.AddListener(VolumeOn);

        _nextButton.onClick.AddListener(NextCharacter);
        _prevButton.onClick.AddListener(PreviousCharacter);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartButton);

        _volumeButton[0].onClick.RemoveListener(VolumeOff);
        _volumeButton[1].onClick.RemoveListener(VolumeOn);

        _nextButton.onClick.RemoveListener(NextCharacter);
        _prevButton.onClick.RemoveListener(PreviousCharacter);
    }

    private void Start()
    {
        IsShowedUI = true;

        LoadVolumeSettings();
        InitializationCharacters();
        Services.Instance.AudioService.PlayMusic(AudioHelper.GetName(AudioType.MainTheme));
        _haveCoins.GetComponent<Text>().text = $"You have: {UserData.LoadMaxCoin()} coins";
    }

    private void StartButton()
    {
        switch (_index)
        {
            case (int)CharacterType.Ortiz:
                ScreenInterface.GetScreenInterface().Execute(ScreenType.GameMenu);
                Services.Instance.GameLevelService.StartGame(CharacterType.Ortiz);
                break;
            case (int)CharacterType.Elvis:
                ScreenInterface.GetScreenInterface().Execute(ScreenType.GameMenu);
                Services.Instance.GameLevelService.StartGame(CharacterType.Elvis);
                break;
        }
    }

    private void LoadVolumeSettings()
    {
        if (Services.Instance.AudioService.SoundIsPlaying())
        {
            _volumeButton[1].gameObject.SetActive(false);
        }
        else
        {
            _volumeButton[0].gameObject.SetActive(false);
        }
    }

    private void VolumeOn()
    {
        Services.Instance.AudioService.SetVolume(1.0f);
        _volumeButton[1].gameObject.SetActive(false);
        _volumeButton[0].gameObject.SetActive(true);
    }

    private void VolumeOff()
    {
        Services.Instance.AudioService.SetVolume(0f);
        _volumeButton[0].gameObject.SetActive(false);
        _volumeButton[1].gameObject.SetActive(true);
    }

    private void InitializationCharacters()
    {
        _images = GetComponentsInChildren<RawImage>();

        for (var i = 0; i < _images.Length; i++)
        {
            _images[i].gameObject.SetActive(false);
        }
        _images[_index].gameObject.SetActive(true);
    }

    private void NextCharacter()
    {
        Services.Instance.AudioService.PlaySound(AudioHelper.GetName(AudioType.Click));

        _images[_index].gameObject.SetActive(false);

        if (_index + 1 == _images.Length)
        {
            _index = 0;
        }
        else
        {
            _index++;
        }

        _images[_index].gameObject.SetActive(true);
    }

    private void PreviousCharacter()
    {
        Services.Instance.AudioService.PlaySound(AudioHelper.GetName(AudioType.Click));

        _images[_index].gameObject.SetActive(false);

        if (_index - 1 == -1)
        {
            _index = _images.Length - 1;
        }
        else
        {
            _index--;
        }

        _images[_index].gameObject.SetActive(true);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }
}