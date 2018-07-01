using UnityEngine;
using System.Collections.Generic;

public class ResourcesResLoader<T> : IResLoader where T : UnityEngine.Object
{
    ResourceRequest m_req;

    public ResourcesResLoader()
        : base()
    {
    }

    public override void StartLoad()
    {
        m_req = Resources.LoadAsync<T>(m_path);
    }

    public override bool IsLoadFinish() 
    { 
        return m_req != null ? m_req.isDone : false; 
    }

    public override float Percent
    {
        get
        {
            return m_req != null ? m_req.progress : 0;
        }
    }

    public override UnityEngine.Object AssetObject
    {
        get
        {
            return m_req != null ? m_req.asset : null;
        }
    }

    public override void Reset()
    {
        base.Reset();
        m_req = null;
    }
}
