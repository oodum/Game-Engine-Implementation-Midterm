using System;
using UnityEngine;
namespace Utility {
    public class Singleton<T> : MonoBehaviour where T : Component {
        static T instance;
        public static bool Exists => instance != null;

        public static T Instance {
            get {
                if (instance == null) {
                    instance = FindAnyObjectByType<T>();
                    if (instance == null) {
                        var go = new GameObject(typeof(T).Name + " (Singleton)");
                        instance = go.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        protected virtual void Awake() {
            if (!Application.isPlaying) return;
            instance = this as T;
        }
        protected virtual void OnDestroy() {
            if (instance == this) {
                instance = null;
            }
        }
    }
}
