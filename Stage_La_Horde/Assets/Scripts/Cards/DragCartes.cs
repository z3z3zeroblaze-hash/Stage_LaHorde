using UnityEngine;
using UnityEngine.EventSystems;

public class DragCartes : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 positionDepart;
    private Transform parentDepart;

    private bool posee = false;


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (posee)
            return;


        positionDepart = transform.position;
        parentDepart = transform.parent;


        transform.SetParent(transform.root);
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (posee)
            return;


        transform.position = Input.mousePosition;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (posee)
            return;


        GameObject objetSousSouris = eventData.pointerCurrentRaycast.gameObject;


        if (objetSousSouris != null)
        {
            CardSlot slot = objetSousSouris.GetComponent<CardSlot>();


            if (slot != null && !slot.occupied)
            {
                slot.PlaceCard(gameObject);

                posee = true;

                return;
            }
        }


        // si mauvais endroit : retour à la position de départ
        transform.position = positionDepart;
        transform.SetParent(parentDepart);
    }
}