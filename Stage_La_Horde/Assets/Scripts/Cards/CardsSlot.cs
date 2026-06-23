using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public bool occupied = false;

    public GameObject carteDansLeSlot;


    public void PlaceCard(GameObject carte)
    {
        if (occupied)
            return;


        carte.transform.position = transform.position;
        carte.transform.SetParent(transform);


        carteDansLeSlot = carte;
        occupied = true;
    }
}