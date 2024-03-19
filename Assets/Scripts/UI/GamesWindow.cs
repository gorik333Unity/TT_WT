using UnityEngine;

namespace UI
{
    public abstract class GamesWindow : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Activate();
        public abstract void Deactivate();

        public abstract event System.Action<GamesWindow> OnClose;
    }
}