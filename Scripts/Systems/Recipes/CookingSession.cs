using System.Collections.Generic;

public class CookingSession
{
    List<string> selectedAppliances;
    List<string> selectedIngredients;
    List<string> selectedAddIns;
    List<string> selectedToppings;
    int currentCookPhase;

    public CookingSession()
    {
        selectedAppliances = new List<string>();
        selectedIngredients = new List<string>();
        selectedAddIns = new List<string>();
        selectedToppings = new List<string>();
    }

    public void changePhase(int phase)
    {
        if( phase <= 1 ) { currentCookPhase = 1; }
        else if( phase >= 3 ){ currentCookPhase = 3; }
        else{ currentCookPhase = phase; }
    }


    // doesnt have checks as it should only be called from ui. will add if problems arise
    public void AddIngredient(string ing)
    {
        selectedIngredients.Add(ing);
    }
    public void RemoveIngredient(string ing)
    {
        selectedIngredients.Remove(ing);
    }


    public void AddAddIn(string ing)
    {
        selectedAddIns.Add(ing);
    }
    public void RemoveAddIn(string ing)
    {
        selectedAddIns.Remove(ing);
    }


    public void AddTopping(string ing)
    {
        selectedToppings.Add(ing);
    }
    public void RemoveTopping(string ing)
    {
        selectedToppings.Remove(ing);
    }

    public void AddAppliance(string ing)
    {
        selectedAppliances.Add(ing);
    }
    public void RemoveAppliance(string ing)
    {
        selectedAppliances.Remove(ing);
    }
}