using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    ImageManager generateImage;

    [SerializeField] GameObject internetErrorPanel_go;
    public static GameObject _internetErrorPanel;

    [SerializeField] int imageHeightLimit, imageWidthLimit;
    public static int _imageHeightLimit, _imageWidthLimit;

    [SerializeField] RawImage image;
    public static RawImage _image;

    [SerializeField] List<string> imagesUrl = new List<string>();


    void Start()
    {
        _imageHeightLimit = imageHeightLimit;
        _imageWidthLimit = imageWidthLimit;
        _image = image;
        _internetErrorPanel = internetErrorPanel_go;

        GenerateMeme();
    }

    public void GenerateMeme()
    {
        int r = Random.Range(0, imagesUrl.Count);
        Meme meme = new Meme(imagesUrl[r]);
    }
}
