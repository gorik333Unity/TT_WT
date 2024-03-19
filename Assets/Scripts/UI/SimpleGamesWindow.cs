using Server.Data;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SimpleGamesWindow : GamesWindow, IGameDataHandler
    {
        [SerializeField]
        private RectTransform _content;

        [SerializeField]
        private GridLayoutGroup _gridParent;

        [SerializeField]
        private Button[] _closeButton;

        private SimpleGameData _gameData;

        public override event Action<GamesWindow> OnClose;

        public override void Initialize()
        {
            InitializeCloseButtons();
        }

        public override void Activate()
        {
            _content.gameObject.SetActive(true);
        }

        public override void Deactivate()
        {
            _content.gameObject.SetActive(false);
        }

        public void InjectData(IGameData gameData)
        {
            if (gameData == null)
            {
                Debug.LogError("Data is null");
                return;
            }
            if (gameData is SimpleGameData simpleGameData)
            {
                _gameData = simpleGameData;
            }
            else
            {
                Debug.LogError("Incorrect data");
                return;
            }

            InitializeGamesWindow();
        }

        private void InitializeGamesWindow()
        {

        }

        private void InitializeCloseButtons()
        {
            foreach (var button in _closeButton)
            {
                button.onClick.RemoveListener(CloseButton_OnClick);
                button.onClick.AddListener(CloseButton_OnClick);
            }
        }

        private void CloseButton_OnClick()
        {
            OnClose?.Invoke(this);
        }
    }
}