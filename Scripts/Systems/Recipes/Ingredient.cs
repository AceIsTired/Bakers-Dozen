using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Scriptable Objects/Ingredient")]
public class Ingredient : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] private string ingName;
    [SerializeField] private string ingID;
    [SerializeField] private string description;
    [SerializeField] private IngredientType ingType;
    [SerializeField] private IngredientRarity ingRarity;
    [SerializeField] private int ingCost;
    [SerializeField] [Range(0, 1000)] private int sweetness, texture, density, aroma;


    // public getters
    public Sprite Icon => icon;
    public string Name => ingName;
    public string ID => ingID;
    public string Description => description;
    public IngredientType IngType => ingType;
    public IngredientRarity Rarity => ingRarity;
    public int IngCost => ingCost;
    public int Sweetness => sweetness;
    public int Texture => texture;
    public int Density => density;
    public int Aroma => aroma;

}
