using UnityEngine;
using UnityEngine.SceneManagement;

public class VoyanteManager : MonoBehaviour
{
    public GameObject[] cartesVoyante;
    public CardSlot[] slots;

    
    public static VoyanteManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PoserDeuxCartes();
    }


    public void PoserDeuxCartes()
    {
        int posees = 0;


        foreach (CardSlot slot in slots)
        {
            if (!slot.occupied)
            {
                GameObject carte = Instantiate(
                    cartesVoyante[Random.Range(0, cartesVoyante.Length)],
                    slot.transform.position,
                    Quaternion.identity
                );


                carte.transform.SetParent(slot.transform);


                slot.occupied = true;
                slot.carteDansLeSlot = carte;


                Debug.Log("Carte voyante posée : " + carte.name);


                posees++;


                if (posees >= 2)
                    break;
            }
        }
    }

    public class RandomExample : MonoBehaviour
    {
        void Start()
        {
            int randomInt = Random.Range(0, 28); // Génère un entier entre 0 (inclus) et 27 (exclus)
            Debug.Log("Nombre entier aléatoire : " + randomInt);
        }
    }

}