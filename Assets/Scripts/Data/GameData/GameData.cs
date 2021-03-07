using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/Game/GameData")]
public sealed class GameData : ScriptableObject
{
    internal bool[] isHeroAvailable;
    internal int coins;

    private string _coin = "Coin";

    private string _ortiz = "Ortiz";
    private string _elvis = "Elvis";
    private string _jammo = "Jammo";

    private int _maxCoin;
    private int _curCoin;

    public void LoadData()
    {
        isHeroAvailable = new bool[3];

        isHeroAvailable[(int)CharacterType.Ortiz] = Services.Instance.SaveData.GetBool(_ortiz, true);
        isHeroAvailable[(int)CharacterType.Elvis] = Services.Instance.SaveData.GetBool(_elvis, false);
        isHeroAvailable[(int)CharacterType.Jammo] = Services.Instance.SaveData.GetBool(_jammo, false);

        coins = LoadMaxCoin();
    }

    public void SaveCharacterData(CharacterType character, bool value)
    {
        isHeroAvailable[(int)character] = value;

        switch (character)
        {
            case CharacterType.Ortiz:
                Services.Instance.SaveData.SetBool(_ortiz, value);
                break;
            case CharacterType.Elvis:
                Services.Instance.SaveData.SetBool(_elvis, value);
                break;
            case CharacterType.Jammo:
                Services.Instance.SaveData.SetBool(_jammo, value);
                break;
        }

        CustomDebug.Log($"Save Data: {character} is {value}");
    }

    public void SaveCoinsData(int coin)
    {
        _curCoin = coin;
        _maxCoin = LoadMaxCoin();
        _maxCoin += _curCoin;
        SaveMaxCoin();

        CustomDebug.Log($"Save Data: maximum coin is {_maxCoin}");
    }

    private int LoadMaxCoin()
    {
        return Services.Instance.SaveData.GetInt(_coin);
    }

    private void SaveMaxCoin()
    {
        Services.Instance.SaveData.SetInt(_coin, _maxCoin);
    }

    public void CleanData()
    {
        Services.Instance.SaveData.DeleteAll();

        CustomDebug.Log("Clean Data");
    }
}