using UnityEngine;
using UnityEngine.UI;

public sealed class MainMenuBehaviour : BaseUI
{
    [SerializeField] private Button[] _startButton = null;
    [SerializeField] private Button[] _volumeButton = null;
    private GameObject _haveCoins;

    private void Awake()
    {
        _haveCoins = GameObject.FindGameObjectWithTag(TagHelper.GetTag(TypeTag.HaveCoinUI));
    }

    private void OnEnable()
    {
        _startButton[0].onClick.AddListener(StartButtonOrtiz);
        _startButton[1].onClick.AddListener(StartButtonElvis);

        _volumeButton[0].onClick.AddListener(VolumeOff);
        _volumeButton[1].onClick.AddListener(VolumeOn);
    }

    private void OnDisable()
    {
        _startButton[0].onClick.RemoveListener(StartButtonOrtiz);
        _startButton[1].onClick.RemoveListener(StartButtonElvis);

        _volumeButton[0].onClick.RemoveListener(VolumeOff);
        _volumeButton[1].onClick.RemoveListener(VolumeOn);
    }

    private void Start()
    {
        IsShowedUI = true;

        LoadVolumeSettings();
        Services.Instance.AudioService.PlayMusic(AudioName.MAIN_THEME);
        _haveCoins.GetComponent<Text>().text = $"You have: {UserData.LoadMaxCoin()} coins";
    }

    private void StartButtonOrtiz()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.GameMenu);
        Services.Instance.GameLevelService.StartGame(CharacterType.Ortiz);
    }

    private void StartButtonElvis()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.GameMenu);
        Services.Instance.GameLevelService.StartGame(CharacterType.Elvis);
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

    public override void Show()
    {
        gameObject.SetActive(true);
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }
}