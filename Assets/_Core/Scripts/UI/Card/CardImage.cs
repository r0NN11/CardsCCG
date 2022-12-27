using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace _Core.Scripts.UI.Card
{
    public class CardImage : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private String _imageUrl = "https://picsum.photos/200/300";
        private Texture2D _texture;


        private async void Awake()
        {
            _texture = await GetRemoteTexture(_imageUrl);
            var sprite = Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height),
                new Vector2(_texture.width / 2, _texture.height / 2));
            _image.overrideSprite = sprite;
        }

        private static async Task<Texture2D> GetRemoteTexture(string url)
        {
            using var www = UnityWebRequestTexture.GetTexture(url);
            var asyncOperation = www.SendWebRequest();
            while (asyncOperation.isDone == false)
                await Task.Delay(1000 / 30);
            if (www.result != UnityWebRequest.Result.Success)
            {
#if DEBUG
                Debug.Log($"{www.error}, URL:{www.url}");
#endif
                return null;
            }
            else
            {
                return DownloadHandlerTexture.GetContent(www);
            }
        }
    }
}