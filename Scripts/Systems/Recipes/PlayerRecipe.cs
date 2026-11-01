using System.Collections.Generic;
using UnityEngine;

public class PlayerRecipe
{
    public string recipeID;
    public List<string> ingredientsUsedIDs;
    public List<string> modifiers;

    public int sweetness { get; private set; }
    public int texture { get; private set; }
    public int density { get; private set; }
    public int aroma { get; private set; }
    public float qualityRating { get; private set; }


    public PlayerRecipe(string id)
    {
        if(id == null)
        {
            recipeID = "R_BOB"; // B.o.B stands for Batch of Bullshit, created when the player makes a.... batch of bullshit

        }
        else
        {
            recipeID = id;
        }

        ingredientsUsedIDs = new List<string>();
        modifiers = new List<string>();
    }

    public void SetSTAD(int s, int t, int a, int d)
    {
        sweetness = s;
        texture = t;
        aroma = a;
        density = d;
    }

    // public void SetStat(char stat, int val)
    // {
    //     stat = char.ToLower(stat);
    //     if(stat == 's')
    //     {
    //         sweetness = val;
    //     }
    //     else if(stat == 't')
    //     {
    //         texture = val;
    //     }
    //     else if(stat == 'a')
    //     {
    //         aroma = val;
    //     }
    //     else if(stat == 'd')
    //     {
    //         density = val;
    //     }
    //     else
    //     {
    //         Debug.Log("[PlayerRecipe] Cannot set recipe stat");
    //     }
    // }

    public void SetQualityRating(float rating)
    {
        if(rating <= 0){
            qualityRating = 0;
        }
        else if (rating >= 3)
        {
            qualityRating = 3;
        }
        else
        {
            qualityRating = rating;
        }
    }

}