using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Gate : MonoBehaviour
{
    [SerializeField] private TMP_Text gateText;
    [SerializeField] private UnityEvent gameEvent;

    private int _gateValue;

    private void Awake()
    {
        _gateValue = Random.Range(20, 50);
        gateText.text = " + " + _gateValue;
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
