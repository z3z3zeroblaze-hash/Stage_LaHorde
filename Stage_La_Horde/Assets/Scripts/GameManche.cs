using UnityEngine;
using UnityEngine.Events;

public class Manche 
{
    public Manche()
    {
        MancheTerminer = new UnityEvent();
    }

    public void bindMancheTerminer(UnityAction action)
    {
        MancheTerminer.AddListener(action);
    }

    public virtual void EnterTransition() 
    {
        Execute();
    }
    public virtual void Execute() 
    {
        ExitTransition();
    }
    public virtual void ExitTransition() 
    {
        MancheTerminer.Invoke();
    }
    UnityEvent MancheTerminer;
};


public class MancheVoyante : Manche 
{
    public override void EnterTransition() 
    {
        // Code spécifique à la MancheVoyante
        base.EnterTransition();
    }
    public override void Execute()
    {
        Debug.Log("MancheVoyante en cours...");
        // Code spécifique à la MancheVoyante
        VoyanteManager.instance.PoserDeuxCartes(); 
        base.Execute();
    }
    public override void ExitTransition() 
    {
        // Code spécifique à la MancheVoyante
        base.ExitTransition();
    }
}

public class MancheJoueur : Manche 
{
    public override void EnterTransition() 
    {
        // Code spécifique à la MancheJoueur
        base.EnterTransition();
    }
    public override void Execute() 
    {
        Debug.Log("MancheJoueur en cours...");
        // Code spécifique à la MancheJoueur
        
    }
}   

public class ManchePlateformer : Manche 
{
    public override void EnterTransition() 
    {
        // Code spécifique à la ManchePlateformer
        base.EnterTransition();
    }
    public override void Execute() 
    {
        Debug.Log("ManchePlateformer en cours...");
        // Code spécifique à la ManchePlateformer
        
    }
} 

