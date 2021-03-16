using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class GameOverMenuBehaviour : BaseMenu
{
    [SerializeField] private Button _restartButton = null;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartButton);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartButton);
    }

    private void Start()
    {
        Services.Instance.AudioService.PlayMusic(AudioHelper.GetName(AudioType.GameOver));
    }

    private void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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