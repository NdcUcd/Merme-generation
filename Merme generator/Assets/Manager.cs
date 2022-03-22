using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    GenerateImage generateImage;
    [SerializeField] GameObject internetErrorPanel_go;
    public static GameObject internetErrorPanel;
    void Start()
    {
        generateImage = FindObjectOfType<GenerateImage>();
        internetErrorPanel = internetErrorPanel_go;
        GenerateMeme();
    }

    public void GenerateMeme()
    {
        generateImage.GenerateNewImage();
    }
}
