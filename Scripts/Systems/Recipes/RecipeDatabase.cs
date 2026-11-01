using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeDatabase", menuName = "Scriptable Objects/RecipeDatabase")]
public class RecipeDatabase : ScriptableObject
{
    [SerializeField] private List<Recipe> allRecipes;
    [SerializeField] private List<Ingredient> allIngredients;
    [SerializeField] private List<Appliance> allAppliances;


    //public getters
    public List<Recipe> AllRecipes => allRecipes;
    public List<Ingredient> AllIngredients => allIngredients;
    public List<Appliance> AllAppliances => allAppliances;


    // public object FindWithID(string id)
    // {
    //     if (id.StartsWith('R')) //Recipe ID Format : R_AA_B_00000 where AA are the first two letters of the family, B is a second classifying Int and 00000 represent the index
    //     {
    //         Recipe recipe = allRecipes.Find(rec => rec.ID == id);
    //         return recipe;
    //     }
    //     else if (id.StartsWith('I'))
    //     {
    //         Ingredient ing = allIngredients.Find(i => i.ID == id);
    //         return ing;
    //     }
    //     else if (id.StartsWith('A'))
    //     {
    //         Appliance app = allAppliances.Find(a => a.ID == id);
    //         return app;
    //     }
    //     else
    //     {
    //         Debug.Log("[RecipeDB] No valid ID!");
    //         return null;
    //     }
    // }

    public Recipe FindRecipe(string id)
    {
        Recipe recipe = allRecipes.Find(rec => rec.ID == id);

        if(recipe == null){ Debug.Log($"[RecipeDB] No found recipe. Id: {id}"); return null; }

        Debug.Log($"[RecipeDB] Found recipe is: {recipe.Name}");
        return recipe;
    }

    public Ingredient FindIngredient(string id)
    {
        Ingredient ing = allIngredients.Find(i => i.ID == id);

        if(ing == null){ Debug.Log($"[RecipeDB] No found ingredient. Id: {id}"); return null; }

        Debug.Log($"[RecipeDB] Found ingredient is: {ing.Name}");
        return ing;
    }

    public Appliance FindAppliance(string id)
    {
        Appliance app = allAppliances.Find(a => a.ID == id);

        if(app == null){ Debug.Log($"[RecipeDB] No found appliance. Id: {id}"); return null; }

        Debug.Log($"[RecipeDB] Found appliance is: {app.Name}");
        return app;
    }
}
