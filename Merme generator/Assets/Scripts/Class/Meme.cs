using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Meme
{
    RawImage image;
    string[] texts;
    GameObject[] textsLocations;

    public Meme(string imageUrl)
    {
        GameObject.Find("Image").GetComponent<ImageManager>()._DownloadImage(imageUrl);
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
