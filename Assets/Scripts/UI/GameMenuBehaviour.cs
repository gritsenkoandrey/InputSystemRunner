using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu = null;
    [SerializeField] private GameObject _gameOver = null;

    private void Start()
    {
        _gameMenu.SetActive(true);
        _gameOver.SetActive(false);
        Services.Instance.TimeService.SetTimeScale(0f);
    }

    public void StartGame()
    {
        _gameMenu.SetActive(false);
        Services.Instance.TimeService.SetTimeScale(1.0f);
    }

    public void RestartGame()
    {
        Services.Instance.TimeService.SetTimeScale(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        _gameOver.SetActive(true);
        Services.Instance.TimeService.SetTimeScale(0f);
    }
}