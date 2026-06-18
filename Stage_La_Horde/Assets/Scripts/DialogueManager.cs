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
        dialogueText.text = steps[index].text;

        if (steps[index].image != null)
            backgroundImage.sprite = steps[index].image;
    }
}