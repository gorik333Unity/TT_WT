using Cysharp.Threading.Tasks;
using Server.Data;
using System;
using UnityEngine.AddressableAssets;

namespace Extensions
{
    public static class AddressableAssetLoader
    {
        public static async UniTask<RequstResult<T>> LoadAsset<T>(string id)
        {
            try
            {
                var asset = await Addressables.LoadAssetAsync<T>(id);
                return new RequstResult<T>(asset);
            }
            catch (Exception exception)
            {
                return new RequstResult<T>(exception);
            }
        }
    }

    public static class AssetService
    {
        //public static async UniTask GetItems<Component>(Component component)
    }
}