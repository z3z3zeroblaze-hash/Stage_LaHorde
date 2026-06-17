using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Bouton PLAY
    public void PlayGame()
    {
        SceneManager.LoadScene("Intro"); // mets le nom de ta scène de jeu ici
    }

    // Bouton CREDITS
    public void Credits()
    {
        SceneManager.LoadScene("Credits"); // scène crédits
    }

    // Bouton QUITTER
    public void QuitGame()
    {
        Debug.Log("Fermeture du jeu...");
        Application.Quit();
    }
}