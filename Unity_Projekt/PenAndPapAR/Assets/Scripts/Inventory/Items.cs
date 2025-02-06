using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Asset/Item")]
public class Items : ScriptableObject
{
    public string itemName;
    [TextArea]
    public string itemDescription;
    public int itemWeight;
    //public Sprite itemSprite;
}
