using UnityEngine;
using System.Collections;

public class ResUtility 
{
    public static string GetResRelativePath(EResType type)
    {
        return GetFolderPath(type) + "/";
    }

    public static string GetResAbsolutePath()
    {
        string ret = "";
#if RES_POLICY_RESOURCES
#elif RES_POLICY_STREAMING
        ret = Application.streamingAssetsPath + "/";
#elif RES_POLICY_EXTERN
        ret = Application.persistentDataPath + "/";
#endif
        return ret;
    }

    private static string GetFolderPath(EResType type)
    {
        switch(type)
        {
            case EResType.ICON:
                return "Icon";
            case EResType.MODEL:
                return "Model";
            case EResType.SOUND:
                return "Sound";
            case EResType.TEXTURE:
                return "Texture";
            case EResType.UI:
                return "UI";
            default:
                return "";
        }
    }
}
