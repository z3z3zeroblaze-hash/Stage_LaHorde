using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [System.Serializable]
    public class CarteSauvegardee
    {
        public GameObject cartePrefab;
        public Vector3 position;
    }


    public List<CarteSauvegardee> cartesPlateau = new List<CarteSauvegardee>();

    public int cartesJoueurPosees = 0;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void SauvegarderCarte(GameObject carte)
    {
        CarteSauvegardee nouvelleCarte = new CarteSauvegardee();

        nouvelleCarte.cartePrefab = carte;
        nouvelleCarte.position = carte.transform.position;


        cartesPlateau.Add(nouvelleCarte);


        Debug.Log("Carte sauvegardée !");
    }


    public bool PeutPoserCarte()
    {
        return cartesJoueurPosees < 2;
    }


    public void CarteJoueurPosee()
    {
        cartesJoueurPosees++;
    }
}