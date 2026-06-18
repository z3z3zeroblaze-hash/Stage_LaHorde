using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadIntro2()
    {
        SceneManager.LoadScene("Intro2");
    }
    public void LoadIntro3()
    {
        SceneManager.LoadScene("Intro3");
    }

    public void LoadIntro4()
    {
        SceneManager.LoadScene("Intro4");
    }

    public void LoadIntro5()
    {
        SceneManager.LoadScene("Intro5");
    }

    public void LoadGame1()
    {
        SceneManager.LoadScene("Game1");
    }
}