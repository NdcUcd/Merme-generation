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
    [SerializeField] List<ListStringWrapper> imagesUrl = new List<ListStringWrapper>();
    public static List<ListStringWrapper> _imagesUrl = new List<ListStringWrapper>();

    public static ImageManager imageManager;

    public TraceryGrammar grammar;

    [SerializeField] TextAsset grammarFile;
    [SerializeField] TextMeshProUGUI titleTMP;
    [SerializeField] GameObject tmpPrefab;

    int i = 0;
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
        imageManager.DeleteCaption();

        int rand_list = 1;  //Random.Range(0, imagesUrl.Count);
        int rand_index = i; //Random.Range(0, imagesUrl[rand_list].list.Count);
        i++;
        Debug.Log(rand_list + " " + rand_index);
        
        Meme meme = new Meme(rand_list, rand_index);

        if (rand_list == 0) {
            titleTMP.text = grammar.Parse(meme.TraceryAttributes);
        }
        else
        {
            titleTMP.text = "";
            MemeWithCaption(meme, rand_index);
        }
    }

    public void MemeWithCaption(Meme meme, int index)
    {
        for (int i = 0; i < CaptionsPositions.data[index].Count; i++)
        {
            GameObject textGo = Instantiate(tmpPrefab);
            textGo.transform.SetParent(image.transform);
            List<int> captionPosition = CaptionsPositions.data[index][i];
            textGo.transform.localPosition = new Vector2(captionPosition[0], captionPosition[1]);
            textGo.transform.GetComponent<TextMeshProUGUI>().text = grammar.Parse(meme.TraceryAttributes);
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
