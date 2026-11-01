using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecipeSysManager : MonoBehaviour
{
    private BakeryStateManager bakery;
    [SerializeField] private RecipeDatabase database;
    private CookingSession currentSession;
    // possible add serialized UI reference here

    public void Initialize(BakeryStateManager _bakery)
    {
        this.bakery = _bakery;

        if(database == null){Debug.Log("[RSM | No database present!]");}
    }

    public void StartCooking() // Called to begin the process
    {
        currentSession = new CookingSession();
        currentSession.changePhase(1);
    }

    // public void // TO DO: NEXT




    // helper functions
    public string CheckRecipe(List<string> playerIngredients, List<string> playerAppliances)
    {
        // check all recipes
        foreach(var recipe in database.AllRecipes)
        {
            // check for same number of ingredients, skip if !=
            if(playerIngredients.Count != recipe.ReqIngredientIDs.Count){ continue; }


            // check if appliances match, skip if !=
            bool hasReqAppliances = true;
            foreach(var app in recipe.ReqApplianceIDs){ if(!playerAppliances.Contains(app)){ hasReqAppliances = false; } }
            if(!hasReqAppliances){ continue; }


            var checkRecipe = recipe.ReqIngredientIDs.Select(id => new string(id)).ToList(); //create a new recipe ingredient list to remove from
            var checkList = playerIngredients.Select(id => new string(id)).ToList(); // ^^^ as above, just with player ing. list


            // check each ingredient: if the ingredient isnt present, skip to the next recipe (BASE INGREDIENTS (STAGE 1 COOKING))
            foreach(var ing in playerIngredients) // check each ing. for a match
            {
            if(checkList.Contains(ing) && checkRecipe.Contains(ing))
                {
                    checkRecipe.Remove(ing);
                    checkList.Remove(ing);
                }
            }

            if(checkRecipe.Count == 0 && checkList.Count == 0){ return recipe.ID; }

        }

        Debug.Log("[RSM] Could not find recipe, returned null!");
        return null;

    }

    public PlayerRecipe NewRecipe(string id, List<string> playerIng)
    {
        // check if given bob, return a bob if true
        if(id == null)
        {
            PlayerRecipe newBOB = new PlayerRecipe(null);
            newBOB.SetSTAD(0, 0, 0, 0);
            newBOB.SetQualityRating(0);
            return newBOB;
        }

        PlayerRecipe newR = new PlayerRecipe(id);
        Recipe recipeRef = database.FindRecipe(id);

        // Set the base values
        newR.SetSTAD( recipeRef.BaseSweetness, recipeRef.BaseTexture, recipeRef.BaseAroma, recipeRef.BaseDensity );

        // Add the ingredients, added stats, and modifiers
        foreach(var ingredient in playerIng)
        {
            newR.ingredientsUsedIDs.Add(ingredient);

            // find the ingredient and add their stat values to the recipe
            Ingredient ingRef = database.FindIngredient(ingredient);
            int newSweet = newR.sweetness + ingRef.Sweetness;
            int newTex = newR.texture + ingRef.Texture;
            int newDen = newR.density + ingRef.Density;
            int newAro = newR.aroma + ingRef.Aroma;

            newR.SetSTAD( newSweet, newTex, newAro, newDen );
        }

        return newR;
    }

}
