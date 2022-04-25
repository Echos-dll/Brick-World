using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    [SerializeField] private GameObject stackingItem;
    [SerializeField] private GameObject stackingParent;
    [SerializeField] private GameObject stackFloor;

    private List<GameObject> _floorList = new List<GameObject>();
    private List<GameObject> _brickList = new List<GameObject>();
    private int _currentFloor;

    private void Start()
    {
        var firstFloor = Instantiate(stackFloor, stackingParent.transform).GetComponent<Floor>();
        _currentFloor = firstFloor.floorCount;
        var pos = stackingParent.transform.position + 
                  new Vector3(0, .4f +  stackingItem.transform.localScale.y * _currentFloor, 1f);
        firstFloor.transform.position = pos;
        _floorList.Add(firstFloor.gameObject);
    }

    public void AddBrick()
    {
        var floor = _floorList[_currentFloor].GetComponent<Floor>();
        if (floor.brickCount < floor.childrens.Count)
        {
            var brick = Instantiate(stackingItem, floor.childrens[floor.brickCount]);
            brick.transform.localPosition = Vector3.zero;
            brick.transform.localRotation = Quaternion.identity;
            floor.brickCount += 1;
        }
        else
        {
            AddFloor();
        }
    }

    private void AddFloor()
    {
        var newFloor = Instantiate(stackFloor, stackingParent.transform).GetComponent<Floor>();
        newFloor.brickCount = 0;
        newFloor.floorCount = _currentFloor + 1;
        _currentFloor = newFloor.floorCount;
        var pos = stackingParent.transform.position + 
                  new Vector3(0, .4f +  stackingItem.transform.localScale.y * _currentFloor, 1f);
        newFloor.transform.position = pos;
        _floorList.Add(newFloor.gameObject);
        AddBrick();
    }

    // public void RemoveItems(int index)
    // {
    //     if (_stackList[index] != null)
    //     {
    //         for (int i = index; i < _stackList.Count; i++)
    //         {
    //             _stackList[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    //             _stackList[i].GetComponent<Brick>().inStack = false;
    //             _stackList[i].transform.parent = null;
    //             stackCount.value -= 1;
    //         }
    //         _stackList.RemoveRange(index, _stackList.Count-index);
    //     }
    //
    //     Reorganize();
    // }

    public void RemoveReorganize()
    {
        
    }

    private void Reorganize()
    {
        
    }
    
    public void PlaceBrick()
    {
        if (_brickList.Count != 0)
        {
            var pos = new Vector3(transform.position.x, .475f, transform.position.z);
            _brickList[^1].transform.position = pos;
            _brickList[^1].transform.parent = null;
            _brickList.RemoveAt(_brickList.Count - 1);
        }
        else
        {
            //Game end
        }
        
        Debug.Log("Building bridge");
    }
}
