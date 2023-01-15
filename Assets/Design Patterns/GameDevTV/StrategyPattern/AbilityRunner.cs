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

    [SerializeField] IAbility currentAbility = new RageAbility();
    
    public void UseAbility()
    {
        currentAbility.Use();

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
    void Use();
}

public class RageAbility : IAbility
{
    public void Use()
    {
        Debug.Log("I'm Always Angry");
    }
}

public class FireballAbility : IAbility
{
    public void Use()
    {
        Debug.Log("Launch Fireball");
    }
}

public class HealAbility : IAbility
{
    public void Use()
    {
        Debug.Log("Self Heal");
    }
}