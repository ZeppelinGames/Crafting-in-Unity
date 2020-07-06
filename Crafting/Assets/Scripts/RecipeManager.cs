using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public ItemSlot[] topRow = new ItemSlot[3];
    public ItemSlot[] midRow = new ItemSlot[3];
    public ItemSlot[] bottomRow = new ItemSlot[3];

    private List<ItemSlot[]> allSlots = new List<ItemSlot[]>();

    [Space(10)]
    public ItemSlot outputSlot;

    private List<RecipeSO> recipes = new List<RecipeSO>();

    // Start is called before the first frame update
    void Start()
    {
        allSlots.Add(topRow);
        allSlots.Add(midRow);
        allSlots.Add(bottomRow);

        recipes.AddRange(Resources.LoadAll<RecipeSO>("Recipes/"));
    }

    // Update is called once per frame
    void Update()
    {
        foreach (RecipeSO recipe in recipes)
        {
            bool correctPlacement = true;

            List<ItemSO[]> allRecipeSlots = new List<ItemSO[]>();
            allRecipeSlots.Add(recipe.topRow);
            allRecipeSlots.Add(recipe.midRow);
            allRecipeSlots.Add(recipe.bottomRow);

            for (int i = 0; i < 3; i++)
            {
                for (int n = 0; n < allRecipeSlots[i].Length; n++)
                {
                    if (allRecipeSlots[i][n] != null)
                    {
                        if (allSlots[i][n].currItem != null)
                        {
                            if (allRecipeSlots[i][n].itemName != allSlots[i][n].currItem.itemName)
                            {
                                correctPlacement = false;
                                continue;
                            }
                        }
                        else
                        {
                            correctPlacement = false;
                            continue;
                        }
                    }
                    else
                    {
                        if(allSlots[i][n].currItem != null)
                        {
                            correctPlacement = false;
                            continue;
                        }
                    }
                }

                if(correctPlacement)
                {
                    outputSlot.currItem = recipe.output;
                    outputSlot.UpdateSlotData();
                }
                else
                {
                    outputSlot.currItem = null;
                    outputSlot.UpdateSlotData();
                }
            }
        }
    }
}
