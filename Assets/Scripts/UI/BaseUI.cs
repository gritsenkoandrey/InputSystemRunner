using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected GameData gameData;
    protected CharacterData charData;

    protected virtual void Awake()
    {
        gameData = Data.Instance.GameData;
        charData = Data.Instance.Character;
    }

    public abstract void Show();
    public abstract void Hide();
}