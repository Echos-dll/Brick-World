using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom Game Event", fileName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> _listenerList = new List<GameEventListener>();

    public void Raise()
    {
        foreach (GameEventListener listener in _listenerList)
        {
            Debug.Log(listener.gameObject.name + " invoked an event");
            listener.OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        _listenerList.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        _listenerList.Remove(listener);
    }
}
