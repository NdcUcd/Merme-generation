using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityTracery;
using TMPro;

public class Manager : MonoBehaviour
{
    [SerializeField] GameObject internetErrorPanel_go;
    public static GameObject _internetErrorPanel;

    [SerializeField] int imageHeightLimit, imageWidthLimit;
    public static int _imageHeightLimit, _imageWidthLimit;

    [SerializeField] RawImage image;
    public static RawImage _image;


    [Tooltip("0 = reactions\n" +
             "1 = images with text")]
    [SerializeField] List<ListWrapper> imagesUrl = new List<ListWrapper>();
    public static List<ListWrapper> _imagesUrl = new List<ListWrapper>();

    public static ImageManager imageManager;

    public TraceryGrammar grammar;

    [SerializeField] TextAsset grammarFile;
    [SerializeField] TextMeshProUGUI titleTMP;


    void Start()
    {
        _imageHeightLimit = imageHeightLimit;
        _imageWidthLimit = imageWidthLimit;
        _image = image;
        _internetErrorPanel = internetErrorPanel_go;
        _imagesUrl = imagesUrl;

        imageManager = FindObjectOfType<ImageManager>();
        grammar = new TraceryGrammar(grammarFile.text);

        GenerateMeme();
    }

    public void GenerateMeme()
    {
        int rand_list = Random.Range(0, imagesUrl.Count);
        int rand_index = Random.Range(0, imagesUrl[rand_list].myList.Count);

        Meme meme = new Meme(rand_list, rand_index);

        titleTMP.text = grammar.Parse(meme.TraceryAttributes);
    }


    public void QuitApp()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    [System.Serializable]
    public class ListWrapper
    {
        public List<string> myList;
    }
}
