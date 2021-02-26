using UnityEngine;
using UnityEngine.UI;

public sealed class MainMenuBehaviour : BaseUI
{
    [SerializeField] private Button _startButtonOrtiz = null;
    [SerializeField] private Button _startButtonElvis = null;
    private GameObject _haveCoins;

    private void Awake()
    {
        _haveCoins = GameObject.FindGameObjectWithTag(TagHelper.GetTag(TypeTag.HaveCoinUI));
    }

    private void OnEnable()
    {
        _startButtonOrtiz.onClick.AddListener(StartButtonOrtiz);
        _startButtonElvis.onClick.AddListener(StartButtonElvis);
    }

    private void OnDisable()
    {
        _startButtonOrtiz.onClick.RemoveListener(StartButtonOrtiz);
        _startButtonElvis.onClick.RemoveListener(StartButtonElvis);
    }

    private void Start()
    {
        isShowedUI = true;

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

    public void PauseButton()
    {
        CustomDebug.Log("StartGame");
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