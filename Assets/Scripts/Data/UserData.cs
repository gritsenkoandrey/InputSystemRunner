using UnityEngine;

public static class UserData
{
    private static string _coin = "Coin";

    private static int _maxCoin;
    private static int _curCoin;

    public static void SaveData(int coin)
    {
        _curCoin = coin;
        _maxCoin = LoadMaxCoin();
        _maxCoin += _curCoin;
        SaveMaxCoin();
        Debug.Log($"Save Data: maximum coin is {_maxCoin}");
    }

    private static int LoadMaxCoin()
    {
        return Services.Instance.SaveData.GetInt(_coin);
    }

    private static void SaveMaxCoin()
    {
        Services.Instance.SaveData.SetInt(_coin, _maxCoin);
    }

    public static void CleanData()
    {
        Services.Instance.SaveData.DeleteAll();
        Debug.Log("Clean Data");
    }
}