using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    [SerializeField] private GameObject stackingItem;
    [SerializeField] private GameObject stackingParent;
    [SerializeField] private IntegerData stackCount;

    private List<GameObject> _stackList = new List<GameObject>();

    private void Start()
    {
        stackCount.value = 0;
    }

    public void AddItem()
    {
        stackCount.value += 1;
        var item = Instantiate(stackingItem, stackingParent.transform);
        var pos = stackingParent.transform.position + 
                  new Vector3(0, .3f +  stackingItem.transform.localScale.y * stackCount.value, .6f);
        item.transform.position = pos;
        item.GetComponent<Brick>().brickIndex = stackCount.value - 1;
        _stackList.Add(item);
    }

    public void RemoveItems(int index)
    {
        if (_stackList[index] != null)
        {
            for (int i = index; i < _stackList.Count; i++)
            {
                _stackList[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                _stackList[i].GetComponent<Brick>().inStack = false;
                _stackList[i].transform.parent = null;
            }
            _stackList.RemoveRange(index, _stackList.Count-index);
        }
    }
}
