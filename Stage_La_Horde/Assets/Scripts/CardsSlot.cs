using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public bool occupied = false;

    public GameObject placedCard;


    public bool CanPlaceCard()
    {
        return !occupied;
    }


    public void PlaceCard(GameObject card)
    {
        if (occupied)
            return;


        placedCard = card;
        occupied = true;

        card.transform.position = transform.position;
    }
}