using UnityEngine;
using System.Collections.Generic;

public class PlayerCardManager : MonoBehaviour
{
    public GameObject[] deckJoueur;

    public Transform emplacementCarte1;
    public Transform emplacementCarte2;


    private List<GameObject> cartesDisponibles;


    void Start()
    {
        cartesDisponibles = new List<GameObject>(deckJoueur);

        PiocherCartes();
    }


    void PiocherCartes()
    {
        CreerCarte(emplacementCarte1);

        CreerCarte(emplacementCarte2);
    }



    void CreerCarte(Transform emplacement)
    {
        int index = Random.Range(0, cartesDisponibles.Count);

        GameObject carte = cartesDisponibles[index];

        cartesDisponibles.RemoveAt(index);


        Instantiate(
            carte,
            emplacement.position,
            Quaternion.identity,
            emplacement
        );
    }
}