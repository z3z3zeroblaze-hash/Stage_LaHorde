using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;


public class Tour
{
    public Tour(List<Manche> manches)
    {
        this.manches = manches;
        this.TourTerminer = new UnityEvent();

        foreach (var manche in manches)
        {
            manche.bindMancheTerminer(OnMancheTerminer);
        }

    }

    public void bindTourTerminer(UnityAction action)
    {
        TourTerminer.AddListener(action);
    }

    List<Manche> manches;
    UnityEvent TourTerminer;

    public void StartTour()
    {
        if (manches.Count > 0)
        {
            currentMancheIndex = 0;
            manches[0].EnterTransition();
        }
    }

    private int currentMancheIndex = 0;

    private void OnMancheTerminer()
    {
        currentMancheIndex++;
        if (currentMancheIndex < manches.Count)
        {
            manches[currentMancheIndex].EnterTransition();
        }
        else
        {
            TourTerminer.Invoke();
        }
    }
}

