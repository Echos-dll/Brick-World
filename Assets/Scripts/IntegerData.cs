using UnityEngine;

[CreateAssetMenu(menuName = ("Data/Integer Data"), fileName = "New Integer Data")]
public class IntegerData : ScriptableObject
{
    public string valueName;
    public int value;
    [TextArea]
    public string description;
}
