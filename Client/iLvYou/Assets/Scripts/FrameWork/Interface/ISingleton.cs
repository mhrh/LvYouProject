using UnityEngine;
using System.Collections;

public class AutoRegisteToUpdate : System.Attribute
{
}

[AutoRegisteToUpdate()]
public class IUpdateable
{
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Dispose() { }
}

public class ISingleton<T> : IUpdateable where T : class, new()
{
    protected static T instance_ = null;

    public static T Instance
    {
        get
        {
            if (instance_ == null)
                instance_ = new T();

            return instance_;
        }
    }
}
