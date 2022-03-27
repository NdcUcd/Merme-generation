using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TitleManager : MonoBehaviour
{
    TextMeshProUGUI title;
    // Start is called before the first frame update
    void Start()
    {
        title = GetComponent<TextMeshProUGUI>();
    }

    void UpdateTitle(string newTitle) { title.text = newTitle; }
}
