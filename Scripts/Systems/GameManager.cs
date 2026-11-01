using UnityEngine;

public class GameManager : MonoBehaviour
{
    // a singleton instance of the manager (is persistant through all scenes)
    public static GameManager Instance {get; private set;}

    // make the serialized fields to plug in the system managers
    [Header("System Managers")]
    [SerializeField] private BakeryStateManager bakeryManager;
    [SerializeField] private RecipeSysManager recipeManager;
    [SerializeField] private CustomerSysManager customerManager;
    [SerializeField] private StaffSysManager staffManager;
    [SerializeField] private AfterHoursSysManager cityManager;

    // make the public read getters
    public BakeryStateManager Bakery => bakeryManager;
    public RecipeSysManager Recipes => recipeManager;
    public CustomerSysManager Customer => customerManager;
    public StaffSysManager Staff => staffManager;
    public AfterHoursSysManager City => cityManager;


    // initialize the managers, make sure instance is persistant
    void Awake()
    {
        if(Instance != null && Instance != this){Destroy(gameObject); return;} // destroy duplicate instances

        // set up the instance to persist between scenes, then set up the system managers
        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeSystems();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //////////////////////////////////
    
    private void InitializeSystems()
    {
        if(CheckSysManagersSet())
        {
            bakeryManager.Initialize();
            recipeManager.Initialize(bakeryManager);
            customerManager.Initialize(bakeryManager, recipeManager);
            staffManager.Initialize(bakeryManager);
            cityManager.Initialize(bakeryManager);

        }

    }

    private bool CheckSysManagersSet()
    {
        if(bakeryManager == null){Debug.LogError("[GM] BakeryStateManager is missing"); return false;}
        if(recipeManager == null){Debug.LogError("[GM] RecipeSysManager is missing"); return false;}
        if(customerManager == null){Debug.LogError("[GM] CustomerSysManager is missing"); return false;}
        if(staffManager == null){Debug.LogError("[GM] StaffSysManager is missing"); return false;}
        if(cityManager == null){Debug.LogError("[GM] AfterHoursSysManager is missing"); return false;}
        return true;
    }
}
