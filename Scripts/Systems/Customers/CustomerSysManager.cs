using UnityEngine;

public class CustomerSysManager : MonoBehaviour
{
    private BakeryStateManager bakery;
    private RecipeSysManager recipe;

    public void Initialize(BakeryStateManager _bakery, RecipeSysManager _recipe)
    {
        this.bakery = _bakery;
        this.recipe = _recipe;
    }
}
