using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public bool occupied = false;


    public void PlaceCard(GameObject card)
    {
        card.transform.position = transform.position;

        occupied = true;
    }
}