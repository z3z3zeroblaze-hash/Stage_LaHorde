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
        // copie du deck pour éviter de retirer les vraies cartes
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
            Debug.Log("Plus de cases disponibles");
            return;
        }


        // choisir une carte au hasard
        int indexCarte = Random.Range(0, cartesDisponibles.Count);

        GameObject carteChoisie = cartesDisponibles[indexCarte];


        // empêche de reprendre la même carte
        cartesDisponibles.RemoveAt(indexCarte);



        GameObject nouvelleCarte = Instantiate(
            carteChoisie,
            caseLibre.transform.position,
            Quaternion.identity
        );


        // place la carte sur la case
        caseLibre.PlaceCard(nouvelleCarte);



        // pour l'instant elle reste visible
        nouvelleCarte.GetComponent<TrapCard>().Cacher();



        cartesParTour--;


        // pose la deuxième après 1 seconde
        Invoke("TourVoyante", 1f);
    }




    CardSlot TrouverCaseLibre()
    {
        List<CardSlot> casesLibres = new List<CardSlot>();


        foreach (CardSlot slot in slots)
        {
            if (!slot.occupied)
            {
                casesLibres.Add(slot);
            }
        }


        if (casesLibres.Count == 0)
        {
            return null;
        }


        int choix = Random.Range(0, casesLibres.Count);


        return casesLibres[choix];
    }
}