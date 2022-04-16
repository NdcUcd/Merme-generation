using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TitleManager : MonoBehaviour
{
    TextMeshProUGUI title;

    void Start()
    {
        title = GetComponent<TextMeshProUGUI>();
    }

    void UpdateTitle(string newTitle) { title.text = newTitle; }
}
