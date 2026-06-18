using UnityEngine;

public class TrapCard : MonoBehaviour
{
    public enum TypeCarte
    {
        Bonus,
        Malus
    }

    public TypeCarte type;

    public bool cachee = false;


    void Start()
    {
        // TEST : la carte reste visible
        MontrerCarte();
    }


    public void Cacher()
    {
        // TEST : on ne cache pas
        cachee = false;
        MontrerCarte();
    }


    public void MontrerCarte()
    {
        cachee = false;

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if (sprite != null)
        {
            sprite.enabled = true;
        }
    }


    public void Reveler()
    {
        cachee = false;

        MontrerCarte();

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