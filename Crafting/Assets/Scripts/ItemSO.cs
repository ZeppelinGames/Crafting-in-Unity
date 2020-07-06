using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New item",menuName ="Item Manager/New Item")]
public class ItemSO : ScriptableObject
{
    public Sprite itemIcon;
    public string itemName;
}
