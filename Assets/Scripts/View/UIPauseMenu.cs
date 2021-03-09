using UnityEngine;

public sealed class UIPauseMenu : MonoBehaviour
{
    private void OnEnable()
    {
        Services.Instance.AudioService.PauseMusic();
        Services.Instance.TimeService.SetTimeScale(0f);
    }

    private void OnDisable()
    {
        Services.Instance.AudioService.UnPauseMusic();
        Services.Instance.TimeService.SetTimeScale(1.0f);
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}