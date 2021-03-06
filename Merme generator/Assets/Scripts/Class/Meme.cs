using UnityEngine;
using UnityEngine.UI;

public class Meme
{
    RawImage image;
    string traceryAttributes;
    GameObject[] textsLocations;

    public Meme(int listIndex, int imageIndex)
    {
        Manager.imageManager._DownloadImage(Manager._imagesUrl[listIndex].list[imageIndex]);    //Download the chosen image
        traceryAttributes = GetTraceryAttributes(listIndex, imageIndex);                        //Determine which outputs will be requested according to the chosen image
        Debug.Log(listIndex + " " + imageIndex);
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

    string GetTraceryAttributes(int listIndex, int imageIndex)
    {
        if (listIndex == 0) return ReactionsMemesAttributes(imageIndex);

        return IllustrationMemesAttributes(imageIndex);
    }

    string ReactionsMemesAttributes(int index) {
        switch (index)
        {
            case 13:
                return "#clever#";
            case 17: case 19:
                return "#deep#";
            default:
                return "#reactions#";
        }
    }

    string IllustrationMemesAttributes(int index) {

        switch (index)
        {
            case 0: case 11:
                return "#subject#/#subject#/#subject#";
            case 1: case 2: case 3:
                return "#people#/#people#";
            case 4:
                return "#politicians#/#politicians#";
            case 5: case 6:  case 7:
                return "#political_duality#";
            case 8:
                return "#political_actions#";
            case 9: case 12: case 13:
                return "#duality#";
            case 10:
                return "#opposites#";
            case 14:
                return "/#duality#";
            case 15: case 16:
                return "#duality#";
            case 17:
                return "#good_bad_food#";
            case 18:
                return "#duality#/#country_or_politicians#";
            case 19:
                return "#things_you_dont_wanna_do#";
            case 20:
                return "#people#/#bravery#";
            case 21: case 22:
                return "#kills#";
            case 23: case 24:
                return "#bad_people#/#bravery#";
            case 25:
                return "#fuckedup_meal#";
            default:
                return "#error#";
        }
    }
}