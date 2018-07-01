using UnityEngine;
using System.Collections;

public class WWWResLoader<T> : IResLoader where T : UnityEngine.Object
{
    WWW m_req;

    public WWWResLoader()
        : base()
    {
    }

    public override void StartLoad()
    {
        App.Instance.StartCoroutine(LoadWWW());
    }

    protected IEnumerator LoadWWW()
    {
        string url = ResUtility.GetResAbsolutePath() + m_path;
        m_req = new WWW(url);
        yield return m_req;
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
            return m_req != null ? m_req.assetBundle.mainAsset : null;
        }
    }

    public override void Reset()
    {
        base.Reset();
        m_req = null;
		App.Instance.StopCoroutine(LoadWWW());
    }
}
