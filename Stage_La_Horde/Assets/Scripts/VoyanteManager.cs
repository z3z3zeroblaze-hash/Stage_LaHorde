using UnityEngine;
using System.Collections.Generic;

public class VoyanteManager : MonoBehaviour
{
    public GameObject[] deck;
    public CardSlot[] slots;

    public int cartesParTour = 2;

    private List<GameObject> cartesDisponibles;


    void Start()
    {
        cartesDisponibles = new List<GameObject>(deck);
        TourVoyante();
    }


    void TourVoyante()
    {
        if (cartesParTour <= 0)
        {
            Debug.Log("Tour de la voyante terminé");
            return;
        }


        CardSlot caseLibre = TrouverCaseLibre();

        if (caseLibre == null)
        {
            Debug.Log("Plus de cases !");
            return;
        }


        int index = Random.Range(0, cartesDisponibles.Count);

        GameObject carteChoisie = cartesDisponibles[index];

        cartesDisponibles.RemoveAt(index);


        GameObject nouvelleCarte = Instantiate(
            carteChoisie,
            caseLibre.transform.position,
            Quaternion.identity
        );


        caseLibre.PlaceCard(nouvelleCarte);


        nouvelleCarte.GetComponent<TrapCard>().Cacher();


        cartesParTour--;

        Invoke("TourVoyante", 1f);
    }



    CardSlot TrouverCaseLibre()
    {
        foreach (CardSlot slot in slots)
        {
            if (!slot.occupied)
            {
                return slot;
            }
        }

        return null;
    }
}