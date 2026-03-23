// ÎÄ¼þ£ºUnityMainThreadDispatcher.cs
using System.Collections.Concurrent;
using UnityEngine;

public class UnityMainThreadDispatcher : MonoBehaviour
{
    private static UnityMainThreadDispatcher instance;
    private ConcurrentQueue<System.Action> actions = new ConcurrentQueue<System.Action>();

    void Update()
    {
        while (actions.TryDequeue(out System.Action action))
        {
            action?.Invoke();
        }
    }

    public static UnityMainThreadDispatcher Instance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("UnityMainThreadDispatcher");
            instance = go.AddComponent<UnityMainThreadDispatcher>();
            DontDestroyOnLoad(go);
        }
        return instance;
    }

    public void Enqueue(System.Action action)
    {
        actions.Enqueue(action);
    }
}