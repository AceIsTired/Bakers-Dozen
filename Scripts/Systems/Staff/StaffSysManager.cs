using UnityEngine;

public class StaffSysManager : MonoBehaviour
{
    private BakeryStateManager bakery;

    public void Initialize(BakeryStateManager _bakery)
    {
        this.bakery = _bakery;
    }
}
