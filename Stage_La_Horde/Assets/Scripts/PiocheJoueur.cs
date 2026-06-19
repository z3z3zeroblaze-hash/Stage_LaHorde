using UnityEngine;
using System.Collections.Generic;

public class PiocheJoueur : MonoBehaviour
{

    public List<GameObject> deck = new List<GameObject>();

    public Transform mainJoueur;

    public int tailleMain = 5;


    void Start()
    {
        DonnerMain();
    }


    void DonnerMain()
    {

        for (int i = 0; i < tailleMain; i++)
        {
            Piocher();
        }

    }



    void Piocher()
    {

        if (deck.Count == 0)
        {
            Debug.Log("Pioche vide");
            return;
        }


        int index = Random.Range(0, deck.Count);


        GameObject carte = deck[index];


        deck.RemoveAt(index);



        Instantiate(
            carte,
            mainJoueur.position,
            Quaternion.identity,
            mainJoueur
        );

        Debug.Log("Carte piochée : " + carte.name);

    }

}