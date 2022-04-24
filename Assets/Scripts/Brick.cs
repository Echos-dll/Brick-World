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
            GetComponentInParent<Stack>().RemoveItems(brickIndex);
        }
    }
}
