using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRunner : MonoBehaviour
{
    //enum Ability
    //{
    //    Fireball,
    //    Rage,
    //    Heal
    //}

    //[SerializeField] IAbility currentAbility = 
    //    new DelayedDecorator(new RageAbility());

    [SerializeField]
    IAbility currentAbility =
        new SequenceComposite(
            new IAbility[]
            {
                new HealAbility(),
                new RageAbility(),
                new DelayedDecorator(new RageAbility())
            });


    public void UseAbility()
    {
        currentAbility.Use(gameObject);

        //switch(currentAbility)
        //{
        //    //case Ability.Fireball:
        //    //    Debug.Log("Launch Fireball");
        //    //    break;

        //    //case Ability.Rage:
        //    //    Debug.Log("I'm Always Angry");
        //    //    break;

        //    //case Ability.Heal:
        //    //    Debug.Log("Self Heal");
        //    //    break;
        //}
    }
}

public interface IAbility
{
    void Use(GameObject gameObject);
}

public class SequenceComposite : IAbility
{
    private IAbility[] children;

    public SequenceComposite(IAbility[] children)
    {
        this.children = children;
    }

    public void Use(GameObject gameObject)
    {
        foreach(var child in children)
        {
            child.Use(gameObject);
        }
    }
}

public class DelayedDecorator : IAbility
{
    private IAbility wrappedAbility;

    public DelayedDecorator(IAbility wrappedAbility)
    {
        this.wrappedAbility = wrappedAbility;
    }

    public void Use(GameObject gameObject)
    {
        // TODO some delayed functionality.
        wrappedAbility.Use(gameObject);
    }
}

public class RageAbility : IAbility
{
    public void Use(GameObject gameObject)
    {
        Debug.Log("I'm Always Angry");
    }
}

public class FireballAbility : IAbility
{
    public void Use(GameObject gameObject)
    {
        Debug.Log("Launch Fireball");
    }
}

public class HealAbility : IAbility
{
    public void Use(GameObject gameObject)
    {
        Debug.Log("Self Heal");
    }
}