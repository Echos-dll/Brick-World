using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public int floorCount = 0;
    public int brickCount = 0;

    public List<Transform> childrens = new List<Transform>();
    
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
        {
            Debug.Log("WTF");
            childrens.Add(transform.GetChild(i));
        }
    }
}
