using UnityEngine;
using System.Collections.Generic;

public class PlayerHand : MonoBehaviour
{
    public GameObject[] deck;

    public Transform mainJoueur;

    public int tailleMain = 5;


    private List<GameObject> cartesDisponibles;


    void Start()
    {
        cartesDisponibles = new List<GameObject>(deck);

        DonnerMain();
    }


    void DonnerMain()
    {
        for (int i = 0; i < tailleMain; i++)
        {
            PiocherCarte(i);
        }
    }


    void PiocherCarte(int emplacement)
    {
        if (cartesDisponibles.Count == 0)
            return;


        int hasard = Random.Range(0, cartesDisponibles.Count);


        GameObject carte = cartesDisponibles[hasard];


        cartesDisponibles.RemoveAt(hasard);



        Instantiate(
            carte,
            mainJoueur.position + new Vector3(emplacement * 130, 0, 0),
            Quaternion.identity,
            mainJoueur
        );
    }
}