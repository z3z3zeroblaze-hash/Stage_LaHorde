using UnityEngine;

public class PlatformLoader : MonoBehaviour
{
    void Start()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ChargerCartes();
        }
        else
        {
            Debug.LogWarning("GameManager introuvable.");
        }
    }
}