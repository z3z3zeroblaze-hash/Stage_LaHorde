using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public bool occupied = false;

    // Compatibilité avec DragCartes
    public bool occupe
    {
        get { return occupied; }
        set { occupied = value; }
    }


    public GameObject cartePosee;


    public bool PlaceCard(GameObject carte)
    {
        if (occupied)
            return false;


        cartePosee = carte;

        occupied = true;

        carte.transform.position = transform.position;

        carte.transform.SetParent(transform);


        return true;
    }
}