using System.Collections.Generic;

public static class TagHelper
{
    private static readonly Dictionary<TypeTag, string> _tags;

    static TagHelper()
    {
        _tags = new Dictionary<TypeTag, string>
        {
            {TypeTag.GAMEOVERUI, "GameOverUI" },
            {TypeTag.PAUSEMENUUI, "PauseMenuUI" },
            {TypeTag.HAVECOINS, "HaveCoins"}
        };
    }

    public static string GetTag(TypeTag tagType)
    {
        return _tags[tagType];
    }
}