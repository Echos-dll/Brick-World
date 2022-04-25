using System.Collections;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int brickIndex;
    public bool inStack = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle")) return;
        if (inStack)
        {
            GetComponentInParent<Stack>().RemoveItems(gameObject);
            StartCoroutine(DestroyAfter());
        }
    }

    private IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Debug.Log("Destroyed");
    }
}
