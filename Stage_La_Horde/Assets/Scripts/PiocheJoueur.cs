using UnityEngine;
using System.Collections.Generic;

public class PiocheJoueur : MonoBehaviour
{
    public List<GameObject> deck = new List<GameObject>();

    public Transform mainJoueur;

    public List<GameObject> cartesMain = new List<GameObject>();


    public int tailleMain = 5;



    void Start()
    {
        DonnerMain();
    }



    public void DonnerMain()
    {
        while (cartesMain.Count < tailleMain && deck.Count > 0)
        {
            Piocher();
        }
    }



    void Piocher()
    {

        int index = Random.Range(0, deck.Count);


        GameObject carte = deck[index];


        deck.RemoveAt(index);



        GameObject nouvelleCarte =
        Instantiate(carte, mainJoueur);


        nouvelleCarte.transform.localPosition =
        new Vector3(cartesMain.Count * 130, 0, 0);


        cartesMain.Add(nouvelleCarte);

    }




    public void RetourDeck(GameObject carte)
    {

        cartesMain.Remove(carte);

        deck.Add(carte);


        Destroy(carte);


        Debug.Log("Carte remise dans le deck");

    }

}