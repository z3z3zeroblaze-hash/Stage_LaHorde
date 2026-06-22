using UnityEngine;
using UnityEngine.EventSystems;

public class DragCarte : MonoBehaviour,
IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Vector3 positionDepart;
    Transform parentDepart;

    bool posee = false;


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (posee)
            return;


        positionDepart = transform.position;
        parentDepart = transform.parent;


        transform.SetParent(
            GameObject.Find("Canvas").transform
        );
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


        GameObject objet =
        eventData.pointerCurrentRaycast.gameObject;



        if (objet != null)
        {

            CardSlot slot =
            objet.GetComponent<CardSlot>();


            if (slot != null && !slot.occupe)
            {

                if (GameManager.instance.PeutPoserCarte())
                {

                    transform.position =
                    slot.transform.position;


                    transform.SetParent(slot.transform);


                    slot.occupe = true;


                    posee = true;


                    GameManager.instance.CarteJoueurPosee();

                    GameManager.instance.SauvegarderCarte(gameObject);

                    Debug.Log("Carte plac�e !");

                    return;
                }

            }

        }


        RetourMain();
    }



    void RetourMain()
    {
        transform.position = positionDepart;

        transform.SetParent(parentDepart);
    }

}