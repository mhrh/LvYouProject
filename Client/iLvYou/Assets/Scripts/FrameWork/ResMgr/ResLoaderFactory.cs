using UnityEngine;
using System.Collections.Generic;

public class ResLoaderFactory
{
    static Dictionary<EResType, Queue<IResLoader>> m_loaderPool = new Dictionary<EResType, Queue<IResLoader>>();

    public static IResLoader GetLoader(EResType type)
    {
        if (!m_loaderPool.ContainsKey(type))
        {
            m_loaderPool[type] = new Queue<IResLoader>();
        }

        if (m_loaderPool[type].Count > 0)
        {
            return m_loaderPool[type].Dequeue();
        }
        else
        {
            switch (type)
            {
                case EResType.MODEL:
                case EResType.UI:
                    return new ResourcesResLoader<GameObject>();
                case EResType.TEXTURE:
                case EResType.ICON:
                    return new ResourcesResLoader<Texture>();
                case EResType.SOUND:
                    return new ResourcesResLoader<AudioClip>();
                default:
                    return null;
            }
        }
    }

    public static void RecycleLoader(IResLoader ld)
    {
        if (!m_loaderPool.ContainsKey(ld.ResType))
        {
            m_loaderPool[ld.ResType] = new Queue<IResLoader>();
        }

        m_loaderPool[ld.ResType].Enqueue(ld);
    }
}
