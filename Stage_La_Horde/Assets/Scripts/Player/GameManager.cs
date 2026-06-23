using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Start()
    {
        _tours.bindTourTerminer(OnTourTerminer);
        _tours.StartTour();
    }
    private void OnTourTerminer()    
    {
        Debug.Log("Tour terminé !");
        //_tours.StartTour();
    }


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

    private Tour _tours = new Tour(new List<Manche>
    {
        new MancheVoyante(),
        new MancheJoueur(),
        new ManchePlateformer()
    });
}