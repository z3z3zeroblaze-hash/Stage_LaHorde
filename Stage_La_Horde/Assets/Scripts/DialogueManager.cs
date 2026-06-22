using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [System.Serializable]
    public class Step
    {
        public string text;
        public Sprite image;
        public string nextSceneName;
        public bool loadNextScene;
    }

    public Step[] steps;

    public TMP_Text dialogueText;
    public Image backgroundImage;

    private int index = 0;

    void Start()
    {
        ShowStep();
    }

    public void Next()
    {
        index++;

        if (index < steps.Length)
        {
            ShowStep();
        }
        else
        {
            SceneManager.LoadScene("Intro2");
        }
    }

    void ShowStep()
    {
        // Vérifie qu'il y a des étapes
        if (steps == null || steps.Length == 0)
        {
            Debug.LogError("Aucune étape configurée dans IntroManager !");
            return;
        }

        // Sécurité pour éviter les erreurs
        if (index >= steps.Length)
        {
            return;
        }

        // Vérifie le texte
        if (dialogueText != null)
        {
            dialogueText.text = steps[index].text;
        }
        else
        {
            Debug.LogError("DialogueText n'est pas relié dans l'Inspector !");
        }

        // Vérifie l'image
        if (backgroundImage != null && steps[index].image != null)
        {
            backgroundImage.sprite = steps[index].image;
        }
    }
}