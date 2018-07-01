using UnityEngine;
using System.Collections.Generic;
using System;

public struct CallBackNode
{
    public ResCallBack callback;
    public object param;
}

public class IResLoader
{
    protected string m_path;
    protected EResType m_resType;

    protected List<CallBackNode> m_callbacks = new List<CallBackNode>();

    public string ResPath
    {
        get
        {
            return m_path;
        }
    }

    public EResType ResType
    {
        get
        {
            return m_resType;
        }
    }

    public virtual float Percent
    {
        get
        {
            return 0; 
        }
    }

    public virtual UnityEngine.Object AssetObject
    { 
        get
        {
            return null; 
        }
    }

    public IResLoader()
    {
    }

    public void SetResPath(string path, EResType type)
    {
        m_path = path;
        m_resType = type;
    }

    public void AddCallBack(ResCallBack callback, object param)
    {
        CallBackNode node = new CallBackNode();
        node.callback = callback;
        node.param = param;

        m_callbacks.Add(node);
    }

    public void CallBack()
    {
        for(int i = 0; i < m_callbacks.Count; i++)
        {
            try
            {
                m_callbacks[i].callback(AssetObject, m_callbacks[i].param);
            }
            catch(System.Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

    public virtual void Reset()
    {
        m_callbacks.Clear();
        m_path = "";
    }

    public virtual void StartLoad()
    {
        
    }

    public virtual bool IsLoadFinish() 
    { 
        return false; 
    }
}
