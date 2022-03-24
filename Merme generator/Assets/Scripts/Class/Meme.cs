using UnityEngine;
using UnityEngine.UI;

public class Meme
{
    RawImage image;
    string[] texts;
    GameObject[] textsLocations;

    public Meme(int imageUrlIndex)
    {
        Manager.imageManager._DownloadImage(Manager._imagesUrl[imageUrlIndex]);
    }

    public RawImage Image
    {
        get { return this.image; }
        set { this.image = value; }
    }

    public string[] Texts
    {
        get { return this.texts; }
        set { this.texts = value; }
    }

    public GameObject[] TextsLocations
    {
        get { return textsLocations; }
        set { textsLocations = value; }
    }
}
