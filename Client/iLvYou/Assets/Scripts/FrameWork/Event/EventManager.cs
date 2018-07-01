using UnityEngine;
using System.Collections.Generic;
using System;

public delegate void EventCallBack(EventArgs e);

public class EventManager:Singleton<EventManager>
{

    private Dictionary<Type, Dictionary<int, Delegate>> eventListeners_ = new Dictionary<Type, Dictionary<int, Delegate>>();


    public void AddListener<T>(EventCallBack cb, int key) where T : EventArgs
    {
        Type t = typeof(T);
        if (!eventListeners_.ContainsKey(t))
        {
            eventListeners_[t] = new Dictionary<int, Delegate>();
        }

        Dictionary<int, Delegate> dic = eventListeners_[t];
        
        Delegate d = null;
        if(dic.TryGetValue(key, out d))
        {
            dic[key] = Delegate.Combine(d, cb);
        }
        else
        {
            dic.Add(key, cb);
        }
    }

    public void RemoveListener<T>(EventCallBack cb, int key) where T : EventArgs
    {
        Type t = typeof(T);
        if (!eventListeners_.ContainsKey(t) || !eventListeners_[t].ContainsKey(key))
        {
            return;
        }

        Dictionary<int, Delegate> dic = eventListeners_[t];

        Delegate d = null;
        if (dic.TryGetValue(key, out d))
        {
            d = dic[key] = Delegate.Remove(d, cb);
        }

        if(d == null)
        {
            dic.Remove(key);
        }
    }

    public void Trigger<T>(T e, int key) where T : EventArgs
    {
        Type t = typeof(T);
        if (!eventListeners_.ContainsKey(t))
        {
            return;
        }

        Dictionary<int, Delegate> dic = eventListeners_[t];

        Delegate d = null;
        if (dic.TryGetValue(key, out d))
        {
            ((EventCallBack)d)(e);
        }

        if (key != -1)
        {
            Delegate all = null;
            if (dic.TryGetValue(-1, out all))
            {
                ((EventCallBack)all)(e);
            }
        }
    }
}
