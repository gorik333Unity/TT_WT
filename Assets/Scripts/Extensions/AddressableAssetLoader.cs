using Cysharp.Threading.Tasks;
using System;
using UnityEngine.AddressableAssets;

namespace Extensions
{
    public static class AddressableAssetLoader
    {
        public static async UniTask LoadAsset<T>(string id, Action<T> onSuccess, Action<Exception> onFail)
        {
            var someAsset = Addressables.LoadAssetAsync<T>(id);
            try
            {
                await someAsset;
                onSuccess?.Invoke(someAsset.Result);
            }
            catch (Exception exception)
            {
                onFail?.Invoke(exception);
            }
            finally
            {

            }
        }
    }
}