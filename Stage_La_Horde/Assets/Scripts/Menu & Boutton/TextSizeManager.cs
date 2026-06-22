using UnityEngine;
using TMPro;

public class TextSizeManager : MonoBehaviour
{
    public TMP_Dropdown textSizeDropdown;
    public TMP_Text[] allTexts;


    void Start()
    {
        // récupère la taille sauvegardée
        int savedSize = PlayerPrefs.GetInt("TextSize", 1);

        textSizeDropdown.value = savedSize;

        ApplyTextSize(savedSize);
    }


    public void ChangeTextSize()
    {
        int choice = textSizeDropdown.value;

        // sauvegarde le choix
        PlayerPrefs.SetInt("TextSize", choice);
        PlayerPrefs.Save();

        ApplyTextSize(choice);
    }


    void ApplyTextSize(int choice)
    {
        switch (choice)
        {
            case 0:
                SetSize(24);
                break;

            case 1:
                SetSize(36);
                break;

            case 2:
                SetSize(50);
                break;

            case 3:
                SetSize(70);
                break;
        }
    }


    void SetSize(float size)
    {
        foreach (TMP_Text text in allTexts)
        {
            text.fontSize = size;
        }
    }
}