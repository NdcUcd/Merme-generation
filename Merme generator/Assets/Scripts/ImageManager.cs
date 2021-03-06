using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    static RawImage image;
    static GameObject _loading;

    private void Awake()
    {
        image = GetComponent<RawImage>();
        _loading = GameObject.Find("Loading");
    }

    public void _DownloadImage(string imageUrl) { StartCoroutine(DownloadImage(imageUrl)); }

    public static IEnumerator DownloadImage(string imageUrl)
    {
        _loading.SetActive(true);

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Manager._internetErrorPanel.SetActive(true);
        else
            DownloadImage(request);

        _loading.SetActive(false);
    }

    static void DownloadImage(UnityWebRequest request)
    {
        Texture downloadedImage = ((DownloadHandlerTexture)request.downloadHandler).texture;
        image.texture = downloadedImage;

        if (image.texture.width > Manager._imageWidthLimit || image.texture.height > Manager._imageHeightLimit)
        {
            Texture imgTexture = image.texture;

            if (image.texture.width > Manager._imageWidthLimit || image.texture.height > Manager._imageHeightLimit)
            {
                if (image.texture.width > Manager._imageWidthLimit)
                {
                    int imageWidthLimit = Manager._imageWidthLimit,
                    imageHeightLimit = Manager._imageHeightLimit;

                    float imageWidth = imgTexture.width;
                    float imageHeight = imgTexture.height;

                    if (imageWidth > imageWidthLimit)
                    {
                        float imageHeightRatio = imageWidthLimit / imageWidth;
                        image.rectTransform.sizeDelta = new Vector2(imageWidthLimit, imageHeight * imageHeightRatio);
                    }

                    imageWidth = image.rectTransform.sizeDelta.x;
                    imageHeight = image.rectTransform.sizeDelta.y;

                    if (imageHeight > imageHeightLimit)
                    {
                        float imageWidthRatio = imageHeightLimit / imageHeight;
                        image.rectTransform.sizeDelta = new Vector2(imageWidth * imageWidthRatio, imageHeightLimit);
                    }
                }

                if (image.texture.height > Manager._imageHeightLimit)
                {
                    int imageWidthLimit = Manager._imageWidthLimit,
                    imageHeightLimit = Manager._imageHeightLimit;

                    float imageWidth = imgTexture.width;
                    float imageHeight = imgTexture.height;


                    if (imageHeight > imageHeightLimit)
                    {
                        float imageWidthRatio = imageHeightLimit / imageHeight;
                        image.rectTransform.sizeDelta = new Vector2(imageWidth * imageWidthRatio, imageHeightLimit);
                    }

                    imageWidth = image.rectTransform.sizeDelta.x;
                    imageHeight = image.rectTransform.sizeDelta.y;

                    if (imageWidth > imageWidthLimit)
                    {
                        float imageHeightRatio = imageWidthLimit / imageWidth;
                        image.rectTransform.sizeDelta = new Vector2(imageWidthLimit, imageHeight * imageHeightRatio);
                    }
                }
            }
        }
        else
        {
            image.rectTransform.sizeDelta = new Vector2(image.texture.width, image.texture.height);
        }
    }

    public void DeleteCaption()
    {
        if (transform.childCount == 0) return;

        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
    }
}
