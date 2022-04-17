using UnityEngine;
using UnityEngine.UI;

public class Meme
{
    RawImage image;
    string traceryAttributes;
    GameObject[] textsLocations;

    public Meme(int listIndex, int imageIndex)
    {
        Manager.imageManager._DownloadImage(Manager._imagesUrl[listIndex].list[imageIndex]);
        if (listIndex == 0)      traceryAttributes = "#reactions#";
        else if (listIndex == 1) traceryAttributes = GetTraceryAttributes(10);
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

    string GetTraceryAttributes(int index)
    {
        switch (index)
        {
            case 10:
                return "#opposites#";
            default:
                return null;
        }
    }
}