using System.Collections;

//不需要挂载
public class Singleton<T> where T : new()
{
    protected static T instance = default(T);
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}