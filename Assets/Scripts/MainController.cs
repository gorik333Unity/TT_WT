using Extensions;
using Server;
using Server.Data;
using UI;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField]
    private GamesWindow _gamesWindow;

    private async void Awake()
    {
        _gamesWindow.Initialize();
        _gamesWindow.OnClose -= GamesWindow_OnClose;
        _gamesWindow.OnClose += GamesWindow_OnClose;

        var apiRequest = new APIRequest(GlobalId.API_URL);
        var result = await apiRequest.GetParsedData<GameDataContainer>(); // Forget() is there to make it clear that await is to be avoided.
        if (result.IsSuccesful)
        {
            ApiRequest_OnSuccess(result.Data);
        }
        else
        {
            ApiRequest_OnFail(result.Exception);
        }
    }

    private void ApiRequest_OnSuccess(GameDataContainer gameData)
    {
        if (_gamesWindow is IGameDataHandler gameDataHandler)
        {
            gameDataHandler.InjectData(gameData);
        }
        else
        {
            Debug.LogError("Not suitable games window");
        }
    }

    private void ApiRequest_OnFail(System.Exception exception)
    {
        Debug.LogError($"Api request fail: {exception.Message}");
    }

    private void GamesWindow_OnClose(GamesWindow obj)
    {
        _gamesWindow.Deactivate();
    }
}