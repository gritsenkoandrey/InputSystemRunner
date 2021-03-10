using UnityEngine;
using UnityEngine.UI;

public sealed class MainMenuBehaviour : BaseUI
{
    [SerializeField] private Button _startButton = null;
    [SerializeField] private Button[] _volumeButton = null;
    [SerializeField] private Button[] _turnButton = null;
    [SerializeField] private Button _cleanButton = null;

    private int _index = 0;
    private RawImage[] _images;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartButton);
        _volumeButton[0].onClick.AddListener(VolumeOff);
        _volumeButton[1].onClick.AddListener(VolumeOn);
        _turnButton[0].onClick.AddListener(NextCharacter);
        _turnButton[1].onClick.AddListener(PrevCharacter);

        _cleanButton.onClick.AddListener(CleanData);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartButton);
        _volumeButton[0].onClick.RemoveListener(VolumeOff);
        _volumeButton[1].onClick.RemoveListener(VolumeOn);
        _turnButton[0].onClick.RemoveListener(NextCharacter);
        _turnButton[1].onClick.RemoveListener(PrevCharacter);

        _cleanButton.onClick.RemoveListener(CleanData);
    }

    private void Start()
    {
        ShowCurrentVolumeButton();
        InitializationImages();
        Services.Instance.AudioService.PlayMusic(AudioHelper.GetName(AudioType.MainTheme));
        Services.Instance.EventService.ShowHaveCoins();
    }

    private void StartButton()
    {
        if (gameData.CharacterIsUnloked[(CharacterType)_index])
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
                case (int)CharacterType.Jammo:
                    ScreenInterface.GetScreenInterface().Execute(ScreenType.GameMenu);
                    Services.Instance.GameLevelService.StartGame(CharacterType.Jammo);
                    break;
            }
        }
        else
        {
            switch (_index)
            {
                case (int)CharacterType.Ortiz:
                    break;
                case (int)CharacterType.Elvis:
                    UnlockCharacter(CharacterType.Elvis, charData.GetCharacterCost(CharacterType.Elvis));
                    break;
                case (int)CharacterType.Jammo:
                    UnlockCharacter(CharacterType.Jammo, charData.GetCharacterCost(CharacterType.Jammo));
                    break;
            }
        }
    }

    private void UnlockCharacter(CharacterType character, int cost)
    {
        if (gameData.Coins >= cost)
        {
            gameData.SaveCoinsData(-cost);
            gameData.SaveCharacterData(character, true);
            gameData.LoadData();
            Services.Instance.AudioService.PlaySound(AudioHelper.GetName(AudioType.Buy));
            Services.Instance.EventService.ShowHaveCoins();
            _startButton.GetComponentInChildren<Text>().text = "Select";
        }
    }

    private void CheckCharacterIsUnlocked()
    {
        switch (_index)
        {
            case (int)CharacterType.Ortiz:
                _startButton.GetComponentInChildren<Text>().text = "Select";
                break;
            case (int)CharacterType.Elvis:
                if (gameData.CharacterIsUnloked[(CharacterType)_index])
                    _startButton.GetComponentInChildren<Text>().text = "Select";
                else _startButton.GetComponentInChildren<Text>().text = $"Cost {charData.GetCharacterCost(CharacterType.Elvis)}";
                break;
            case (int)CharacterType.Jammo:
                if (gameData.CharacterIsUnloked[(CharacterType)_index])
                    _startButton.GetComponentInChildren<Text>().text = "Select";
                else _startButton.GetComponentInChildren<Text>().text = $"Cost {charData.GetCharacterCost(CharacterType.Jammo)}";
                break;
        }
    }

    private void ShowCurrentVolumeButton()
    {
        if (Services.Instance.AudioService.SoundIsPlaying())
            _volumeButton[1].gameObject.SetActive(false);
        else _volumeButton[0].gameObject.SetActive(false);
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

    private void InitializationImages()
    {
        charData.InitializationImage(gameObject.transform);
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
        if (_index + 1 == _images.Length) _index = 0;
        else _index++;
        _images[_index].gameObject.SetActive(true);
        CheckCharacterIsUnlocked();
    }

    private void PrevCharacter()
    {
        Services.Instance.AudioService.PlaySound(AudioHelper.GetName(AudioType.Click));
        _images[_index].gameObject.SetActive(false);
        if (_index - 1 == -1) _index = _images.Length - 1;
        else _index--;
        _images[_index].gameObject.SetActive(true);
        CheckCharacterIsUnlocked();
    }

    private void CleanData()
    {
        gameData.CleanData();
        gameData.LoadData();
        Services.Instance.EventService.ShowHaveCoins();
        CheckCharacterIsUnlocked();
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