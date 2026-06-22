using UnityEngine;

public class CarteLoader : MonoBehaviour
{
    void Start()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ChargerCartes();
        }
        else
        {
            Debug.LogError("Pas de GameManager !");
        }
    }
}