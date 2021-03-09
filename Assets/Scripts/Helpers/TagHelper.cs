using System.Collections.Generic;

public static class TagHelper
{
    private static readonly Dictionary<TagType, string> _tags;

    static TagHelper()
    {
        _tags = new Dictionary<TagType, string>
        {
            { TagType.None, "None" }
        };
    }

    public static string GetTag(TagType tagType)
    {
        return _tags[tagType];
    }
}