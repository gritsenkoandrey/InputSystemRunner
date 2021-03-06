using System.Collections.Generic;

public static class TagHelper
{
    private static readonly Dictionary<TypeTag, string> _tags;

    static TagHelper()
    {
        _tags = new Dictionary<TypeTag, string>
        {
            { TypeTag.GameOverUI, "GameOverUI" },
            { TypeTag.PauseMenuUI, "PauseMenuUI" },
            { TypeTag.GameMenuUI, "GameMenuUI" },
            { TypeTag.HaveCoinUI, "HaveCoinsUI" }
        };
    }

    public static string GetTag(TypeTag tagType)
    {
        return _tags[tagType];
    }
}