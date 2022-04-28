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
             "1 = illustrations (images with text)")]
    [SerializeField] List<ListStringWrapper> imagesUrl = new List<ListStringWrapper>();
    public static List<ListStringWrapper> _imagesUrl = new List<ListStringWrapper>();

    public static ImageManager imageManager;

    public TraceryGrammar grammar;

    [SerializeField] TextAsset grammarFile;
    [SerializeField] TextMeshProUGUI titleTMP;
    [SerializeField] GameObject tmpPrefab;

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

    int i = 0;
    public void GenerateMeme()
    {
        imageManager.DeleteCaption();   //Delete previous caption

        int rand_list = Random.Range(0, imagesUrl.Count);                   //Randomly chose a list
        int rand_index = Random.Range(0, imagesUrl[rand_list].list.Count);  //Randomly chose an image from that list
        
        Meme meme = new Meme(rand_list, rand_index);

        if (rand_list == 0) {   //Reaction memes
            titleTMP.text = grammar.Parse(meme.TraceryAttributes);  //Fetch an output in the .json file according to the value given as parameter 
                                                                    //To do that, the Tracery plug-in is used
        }
        else                    //Illustration memes
        {
            titleTMP.text = ""; //We don't need a title for illustration memes
            MemeWithCaption(meme, rand_index);  //This function splits the generated output and positions the different parts in the right place on the image
        }
    }

    public void MemeWithCaption(Meme meme, int index)
    {
        string[] textGenerated = grammar.Parse(meme.TraceryAttributes).Split('/');

        for (int i = 0; i < CaptionsPositions.data[index].Count; i++)
        {
            Transform textGoTransform = Instantiate(tmpPrefab).transform;
            textGoTransform.SetParent(image.transform);
            List<int> captionPosition = CaptionsPositions.data[index][i];
            textGoTransform.localPosition = new Vector2(captionPosition[0], captionPosition[1]);
            textGoTransform.GetComponent<TextMeshProUGUI>().text = textGenerated[i];
        }
    }


    public void QuitApp()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    [System.Serializable]
    public class ListStringWrapper
    {
        public List<string> list;
    }
}
