using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Gate : MonoBehaviour
{
    public UnityEvent gameEvent;
    private int _gateValue;

    private void Awake()
    {
        _gateValue = Random.Range(20, 50);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        for (int i = 0; i < _gateValue; i++)
        {
            gameEvent.Invoke();   
        }
    }
}
