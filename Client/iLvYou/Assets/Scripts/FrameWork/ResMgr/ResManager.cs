using UnityEngine;
using System.Collections.Generic;
using System;

public delegate void ResCallBack(UnityEngine.Object obj, object param);

public class ResManager : ISingleton<ResManager>
{
    private Dictionary<string, UnityEngine.Object> m_resPool = new Dictionary<string, UnityEngine.Object>();
    private Dictionary<string, IResLoader> m_activeLoader = new Dictionary<string, IResLoader>();

    public void GetRes(string name, EResType type, ResCallBack callback, object param)
    {
        string path = ResUtility.GetResRelativePath(type) + name;

        if (m_resPool.ContainsKey(path))
        {
            callback(m_resPool[path], param);
        }
        else
        {
            IResLoader loader = GetLoader(path, type);
            loader.AddCallBack(callback, param);

            m_activeLoader[path] = loader;

            loader.StartLoad();
        }
    }

    private IResLoader GetLoader(string path, EResType type)
    {
        IResLoader loader;
        if (!m_activeLoader.ContainsKey(path))
        {
            loader = ResLoaderFactory.GetLoader(type);
            loader.SetResPath(path, type);
        }
        else
        {
            loader = m_activeLoader[path];
        }

        return loader;
    }

    List<IResLoader> m_finishedLoader = new List<IResLoader>();
    public override void FixedUpdate()
    {
        m_finishedLoader.Clear();
        foreach(var kv in m_activeLoader)
        {
            IResLoader ld = kv.Value;
            if (ld.IsLoadFinish())
            {
                m_resPool[ld.ResPath] = ld.AssetObject;

                ld.CallBack();
                ld.Reset();
                m_finishedLoader.Add(ld);
            }
        }

        for(int i = 0; i < m_finishedLoader.Count; i++)
        {
            IResLoader ld = m_finishedLoader[i];

            m_activeLoader.Remove(ld.ResPath);

            ResLoaderFactory.RecycleLoader(ld);
        }
    }
}