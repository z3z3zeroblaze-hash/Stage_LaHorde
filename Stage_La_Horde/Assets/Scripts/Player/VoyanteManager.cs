using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class VoyanteManager : MonoBehaviour
{
    public GameObject[] cartesVoyante;
    public CardSlot[] slots;

    [Header("UI")]
    public TMP_Text texteTour;

    [Header("Tour du joueur")]
    public GameObject mainJoueur;

    public static VoyanteManager instance;

    private bool cartesDejaPosees = false;

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
        if (texteTour != null)
        {
            texteTour.gameObject.SetActive(false);
        }

        if (mainJoueur != null)
        {
            mainJoueur.SetActive(false);
        }

        PoserDeuxCartes();
    }

    public void PoserDeuxCartes()
    {
        if (cartesDejaPosees)
        {
            Debug.Log("Les cartes ont déjà été posées.");
            return;
        }

        cartesDejaPosees = true;

        int cartesAPoser = 2;

        for (int i = 0; i < cartesAPoser; i++)
        {
            List<CardSlot> slotsLibres = new List<CardSlot>();

            foreach (CardSlot slot in slots)
            {
                if (!slot.occupied)
                {
                    slotsLibres.Add(slot);
                }
            }

            if (slotsLibres.Count == 0)
            {
                Debug.LogWarning("Plus aucun slot libre !");
                return;
            }

            CardSlot slotChoisi = slotsLibres[Random.Range(0, slotsLibres.Count)];

            GameObject carteChoisie = cartesVoyante[
                Random.Range(0, cartesVoyante.Length)
            ];

            GameObject carte = Instantiate(
                carteChoisie,
                slotChoisi.transform.position,
                Quaternion.identity
            );

            carte.transform.SetParent(slotChoisi.transform);

            slotChoisi.occupied = true;
            slotChoisi.carteDansLeSlot = carte;
        }

        StartCoroutine(AfficherTourJoueur());
    }

    IEnumerator AfficherTourJoueur()
    {
        if (texteTour != null)
        {
            texteTour.gameObject.SetActive(true);
            texteTour.text = "Tour du Joueur";
        }

        yield return new WaitForSeconds(3f);

        if (texteTour != null)
        {
            texteTour.gameObject.SetActive(false);
        }

        if (mainJoueur != null)
        {
            mainJoueur.SetActive(true);
        }

        Debug.Log("Tour du joueur commencé");
    }
}