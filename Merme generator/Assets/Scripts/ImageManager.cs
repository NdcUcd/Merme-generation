using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    [SerializeField] List<string> imagesUrl = new List<string>();
    [SerializeField] int imageHeightLimit, imageWidthLimit;
    static RawImage image;
    static GameObject _loading;

    private void Awake()
    {
        image = GetComponent<RawImage>();
        _loading = transform.GetChild(0).gameObject;
    }

    public void GenerateNewImage()
    {
        int r = Random.Range(0, imagesUrl.Count);
        StartCoroutine(DownloadImage(imagesUrl[r]));
    }

    public void _DownloadImage(string imageUrl) { StartCoroutine(DownloadImage(imageUrl)); }

    public static IEnumerator DownloadImage(string imageUrl)
    {
        _loading.SetActive(true);

        int imageWidthLimit = Manager._imageWidthLimit,
            imageHeightLimit = Manager._imageHeightLimit;

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Manager._internetErrorPanel.SetActive(true);
        }
        else
        {
            Texture downloadedImage = ((DownloadHandlerTexture)request.downloadHandler).texture;

            float imageWidth = downloadedImage.width;
            float imageHeight = downloadedImage.height;

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


            image.texture = downloadedImage;
           // image.rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);



        }

        _loading.SetActive(false);
    }
}
