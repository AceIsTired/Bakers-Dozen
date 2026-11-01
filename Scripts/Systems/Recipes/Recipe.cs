using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Scriptable Objects/Recipe")]
public class Recipe : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] private string recipeName;
    [SerializeField] private string recipeID;
    [SerializeField] private string description;
    [SerializeField] private List<string> reqIngredientIDs;
    [SerializeField] private List<string> reqApplianceIDs;
    [SerializeField] private string recipeFamily;
    [SerializeField] private RecipeRarity rarity;
    [SerializeField] private int recipeCost;

    [Header("Base Stats")]
    [SerializeField] [Range(0, 1000)] private int baseSweetness;
    [SerializeField] [Range(0, 1000)] private int baseTexture;
    [SerializeField] [Range(0, 1000)] private int baseDensity;
    [SerializeField] [Range(0, 1000)] private int baseAroma;


    // public getters
    public Sprite Icon => icon;
    public string Name => recipeName;
    public string ID => recipeID;
    public string Description => description;
    public List<string> ReqIngredientIDs => reqIngredientIDs;
    public List<string> ReqApplianceIDs => reqApplianceIDs;
    public string RecipeFamily => recipeFamily;
    public RecipeRarity Rarity => rarity;
    public int RecipeCost => recipeCost;
    public int BaseSweetness => baseSweetness;
    public int BaseTexture => baseTexture;
    public int BaseDensity => baseDensity;
    public int BaseAroma => baseAroma;


}
