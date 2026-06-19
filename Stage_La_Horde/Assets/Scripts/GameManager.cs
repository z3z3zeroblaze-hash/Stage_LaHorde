using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [System.Serializable]
    public class CarteSauvegardee
    {
        public string nomPrefab;
        public Vector3 position;
    }


    public List<CarteSauvegardee> cartesPlateau = new List<CarteSauvegardee>();
    public GameObject[] tousLesPrefabs;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            cartesPlateau.Clear();
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void SauvegarderCarte(GameObject carte)
    {
        if (carte == null)
            return;

        CarteSauvegardee data = new CarteSauvegardee();

        data.nomPrefab = carte.name.Replace("(Clone)", "");
        data.position = carte.transform.position;

        cartesPlateau.Add(data);

        Debug.Log("Sauvegarde : " + data.nomPrefab);
    }



    public void ChargerCartes()
    {
        foreach (CarteSauvegardee data in cartesPlateau)
        {
            foreach (GameObject prefab in tousLesPrefabs)
            {
                if (prefab.name == data.nomPrefab)
                {
                    Instantiate(
                        prefab,
                        data.position,
                        Quaternion.identity
                    );

                    break;
                }
            }
        }
    }


    public int cartesJoueurPosees = 0;

    public bool PeutPoserCarte()
    {
        return cartesJoueurPosees < 2;
    }


    public void CarteJoueurPosee()
    {
        cartesJoueurPosees++;

        Debug.Log("Cartes joueur posées : " + cartesJoueurPosees);
    }


}