using UnityEngine;
using UnityEngine.UI;

public class Meme
{
    RawImage image;
    string traceryAttributes;
    GameObject[] textsLocations;

    public Meme(int imageUrlIndex)
    {
        Manager.imageManager._DownloadImage(Manager._imagesUrl[imageUrlIndex]);
        traceryAttributes = "#animal# #mood#";
    }

    public RawImage Image
    {
        get { return this.image; }
        set { this.image = value; }
    }

    public string TraceryAttributes
    {
        get { return this.traceryAttributes; }
        set { this.traceryAttributes = value; }
    }

    public GameObject[] TextsLocations
    {
        get { return textsLocations; }
        set { textsLocations = value; }
    }
}
