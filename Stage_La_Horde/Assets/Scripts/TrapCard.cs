using UnityEngine;

public class TrapCard : MonoBehaviour
{
    public enum TypeCarte
    {
        Bonus,
        Malus
    }

    public TypeCarte type;


    public bool cachee = true;


    public void Cacher()
    {
        cachee = true;

        // cache juste le sprite
        GetComponent<SpriteRenderer>().enabled = false;
    }


    public void Reveler()
    {
        cachee = false;

        GetComponent<SpriteRenderer>().enabled = true;

        ActiverEffet();
    }


    void ActiverEffet()
    {
        if (type == TypeCarte.Bonus)
        {
            Debug.Log("Carte BONUS !");
        }
        else
        {
            Debug.Log("Carte MALUS !");
        }
    }
}