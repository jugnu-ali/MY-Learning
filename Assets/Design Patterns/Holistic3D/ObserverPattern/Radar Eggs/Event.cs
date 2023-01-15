using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "GameEvent", order = 52)]
public class Event : ScriptableObject
{
    private List<EventListener> eListener = new List<EventListener>();

    public void Register(EventListener listener)
    {
        eListener.Add(listener);
    }

    public void UnRegister(EventListener listener)
    {
        eListener.Remove(listener);
    }

    public void Occured(GameObject go)
    {
        for(int i = 0; i < eListener.Count; ++i)
        {
            eListener[i].OnEventOccured(go);
        }
    }
}
