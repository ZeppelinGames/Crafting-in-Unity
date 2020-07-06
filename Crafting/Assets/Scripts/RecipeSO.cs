using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New recipe",menuName ="Item Manager/New Recipe")]
public class RecipeSO : ScriptableObject
{
    public ItemSO[] topRow = new ItemSO[3];
    public ItemSO[] midRow = new ItemSO[3];
    public ItemSO[] bottomRow = new ItemSO[3];

    public ItemSO output;
}
