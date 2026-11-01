using UnityEngine;

public class AfterHoursSysManager : MonoBehaviour
{
    private BakeryStateManager bakery;

    public void Initialize(BakeryStateManager _bakery)
    {
        this.bakery = _bakery;
    }
}
