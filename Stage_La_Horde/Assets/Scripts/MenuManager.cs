using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Bouton PLAY
    public void PlayGame()
    {
        SceneManager.LoadScene("Intro"); // mets le nom de ta sc�ne de jeu ici
    }

    // Bouton CREDITS
    public void Credits()
    {
        SceneManager.LoadScene("Credits"); // sc�ne cr�dits
    }

    // Bouton QUITTER
    public void QuitGame()
    {
        Debug.Log("Fermeture du jeu...");
        Application.Quit();
    }

    // Bouton RETOUR
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // sc�ne menu principal
    }

    // Bouton Parametres
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings"); // sc�ne param�tres 
    }
    public void LoadGame3()
    {
        SceneManager.LoadScene("Game3"); // mets le nom de ta sc�ne de jeu ici
    }
}