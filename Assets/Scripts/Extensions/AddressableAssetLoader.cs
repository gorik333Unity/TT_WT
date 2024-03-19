using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Extensions
{
    public static class AddressableAssetLoader
    {
        public static async UniTask<RequstResult<T>> LoadAsset<T>(string id) where T : Component
        {
            try
            {
                var asset = await Addressables.LoadAssetAsync<GameObject>(id);
                if (asset.TryGetComponent<T>(out var component))
                {
                    return new RequstResult<T>(component);
                }
                else
                {
                    return new RequstResult<T>(new Exception("Component not found"));
                }
            }
            catch (Exception exception)
            {
                return new RequstResult<T>(exception);
            }
        }
    }
}