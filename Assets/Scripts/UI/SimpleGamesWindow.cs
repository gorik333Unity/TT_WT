using Cysharp.Threading.Tasks;
using Extensions;
using Server.Data;
using System;
using System.Collections.Generic;
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
        private string _assetName;

        [SerializeField]
        private Button[] _closeButton;

        private GameDataContainer _gameDataContainer;
        private readonly List<SimpleGameItem> _currentSimpleGameItem = new List<SimpleGameItem>();

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

        public async void InjectData(GameDataContainer gameDataContainer)
        {
            if (gameDataContainer == null || gameDataContainer.Games.Length == 0)
            {
                Debug.LogError("Data is null or empty");
                return;
            }

            _gameDataContainer = gameDataContainer;

            var result = await AddressableAssetLoader.LoadAsset<GameObject>(_assetName);
            if (result.IsSuccesful)
            {
                if (result.Data.TryGetComponent(out SimpleGameItem gameItem))
                {
                    AssetLoader_OnSuccess(gameItem);
                }
                else
                {
                    Debug.LogError("Some error");
                }
            }
            else
            {
                AssetLoader_OnFail(result.Exception);
            }
        }

        private void AssetLoader_OnSuccess(SimpleGameItem simpleGameItem)
        {
            foreach (var item in _currentSimpleGameItem)
            {
                Destroy(item.gameObject);
            }
            _currentSimpleGameItem.Clear();

            var games = _gameDataContainer.Games;
            var parent = _gridParent.GetComponent<RectTransform>();
            foreach (var item in games)
            {
                var gameUI = Instantiate(simpleGameItem, parent);
                gameUI.SetTitleText(item.Title);
                gameUI.SetDescriptionText(item.Description);
                gameUI.SetReleaseDateText(item.ReleaseDate.ToString());

                _currentSimpleGameItem.Add(gameUI);
            }
        }

        private void AssetLoader_OnFail(Exception exception)
        {
            Debug.LogError(exception.Message);
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