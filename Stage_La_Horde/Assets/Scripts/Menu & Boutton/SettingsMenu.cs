using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject gameplayPanel;
    public GameObject graphicsPanel;
    public GameObject audioPanel;
    public GameObject controlsPanel;


    public void OpenGameplay()
    {
        gameplayPanel.SetActive(true);
        graphicsPanel.SetActive(false);
        audioPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }


    public void OpenGraphics()
    {
        gameplayPanel.SetActive(false);
        graphicsPanel.SetActive(true);
        audioPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }


    public void OpenAudio()
    {
        gameplayPanel.SetActive(false);
        graphicsPanel.SetActive(false);
        audioPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }


    public void OpenControls()
    {
        gameplayPanel.SetActive(false);
        graphicsPanel.SetActive(false);
        audioPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }
}