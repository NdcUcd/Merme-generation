using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GenerateImage : MonoBehaviour
{
    [SerializeField] List<string> imagesUrl = new List<string>();
    [SerializeField] int imageHeightLimit, imageWidthLimit;
    RawImage image;

    private void Start()
    {
        image = GetComponent<RawImage>();
    }

    public void GenerateNewImage()
    {
        int r = Random.Range(0, imagesUrl.Count);
        StartCoroutine(DownloadImage(imagesUrl[r]));
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Manager.internetErrorPanel.SetActive(true);
        }
        else
        {
            Texture downloadedImage = ((DownloadHandlerTexture)request.downloadHandler).texture;
            //Texture imageTexture = downloadedImage;

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
    }
}
