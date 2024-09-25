using UnityEngine;

namespace UnityDevTools
{
    public class SingletonUtil<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static readonly object _lock = new object();

        public static T Instance
        {
            get
            {
                // 确保只在主线程中调用
                if (Application.isPlaying && !IsMainThread())
                {
                    Debug.LogWarning($"Singleton<{typeof(T)}> should only be accessed from the main thread.");
                    return null;
                }

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = FindObjectOfType<T>();

                        if (_instance == null)
                        {
                            GameObject singletonObject = new GameObject();
                            _instance = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T).Name + " (Singleton)";

                            DontDestroyOnLoad(singletonObject);
                        }
                    }

                    return _instance;
                }
            }
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null; // 允许下一次访问创建新实例
            }
        }

        private static bool IsMainThread()
        {
            return System.Threading.Thread.CurrentThread.ManagedThreadId == 1;
        }
    }
}