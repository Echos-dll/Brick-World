using System.Collections;
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
        _gateValue = Random.Range(100, 400);
        gateText.text = " + " + _gateValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        StartCoroutine(StackUp());
    }

    private IEnumerator StackUp()
    {
        for (int i = 0; i < _gateValue; i++)
        {
            gameEvent.Invoke();
            yield return new WaitForSeconds(.01f);
        }
    }
}
