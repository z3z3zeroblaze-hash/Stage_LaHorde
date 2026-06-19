using UnityEngine;
using UnityEngine.EventSystems;

public class DragCarte : MonoBehaviour,
IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 positionDepart;
    private Transform parentDepart;

    public bool posee = false;


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


        GameObject objet = eventData.pointerCurrentRaycast.gameObject;


        if (objet != null)
        {
            CardSlot slot = objet.GetComponent<CardSlot>();

            if (slot != null && !slot.occupied)
            {
                PoserCarte(slot);
                return;
            }
        }


        RetourMain();
    }



    void PoserCarte(CardSlot slot)
    {
        if (!GameManager.instance.PeutPoserCarte())
        {
            RetourMain();
            return;
        }


        transform.position = slot.transform.position;

        transform.SetParent(slot.transform);


        slot.occupied = true;

        posee = true;


        GameManager.instance.CarteJoueurPosee();

        Debug.Log("Carte joueur posée");
    }



    void RetourMain()
    {
        transform.position = positionDepart;
        transform.SetParent(parentDepart);
    }
}