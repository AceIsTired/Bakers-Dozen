# Bakery Scripts

## Core Managers

**GameManager.cs** - The persistent singleton that owns and initializes every other manager.
> Enforces the singleton in `Awake()`, calls `DontDestroyOnLoad`, then runs `InitializeSystems()`. Order matters here: bakery first, then recipe, customer, staff, and city, because everything downstream takes the bakery manager as a reference. `CheckSysManagersSet()` logs an error for any missing serialized manager, so a broken scene setup fails loudly instead of null reffing later.

**BakeryStateManager.cs** - Owns the clock and drives the bakery phase.
> `Update()` calls `DoTimeTick()`, which advances time 10 minutes every 1.5 seconds and then calls `CheckPhase()`. The schedule is hardcoded: prep at 6:00, open at 9:00, closing at 18:00, shut at 19:00. `BSMPrintDebugState()` logs the current time and phase on every tick, which is useful while testing but will probably need to be gated behind a debug flag before the demo.

## State and Session Data

**BakeryState.cs** - The save-state of the bakery. Money, reputation, day count, current time, weather, active events, staff, held recipes, and ingredient stock.
> Time handling is the interesting part. `GetFTime` rolls minutes into hours, floors everything to 10 minute intervals, and clamps anything past 24 hours to 23:50 so the day just ends on its own. `SetTime` has a range check that currently only logs a message and doesn't actually stop the assignment, so that needs a real `return` before it can be trusted.

**PlayerRecipe.cs** - The result of a cooking session. Holds computed stats, quality rating, ingredients used, and modifiers.
> A null ID defaults to `"R_BOB"`, which the comment explains is the fallback "batch of bullshit" recipe created when the player makes something the system can't recognize. Quality is clamped between 0 and 3 in `SetQualityRating`.

**CookingSession.cs** - Tracks what the player has selected during a cook. Appliances, ingredients, add-ins, toppings, and current phase.
> `changePhase` clamps to 1 through 3. The Add and Remove methods have no validation because the comment says only the UI calls them, and that's fine for now but will need revisiting once other systems start touching the session.

## Recipe Systems

**RecipeSysManager.cs** - The core of the cooking loop. Starts sessions, matches player picks against recipes, and builds the final PlayerRecipe.
> `CheckRecipe` does the matching in three passes: same ingredient count, all required appliances present, then a multiset comparison so duplicate and out of order ingredients still match correctly. Returns a recipe ID or null.
> `NewRecipe` takes that ID, pulls the base stats from the Recipe asset, then adds every ingredient's stat values on top. If the ID is null it returns a BOB with all zeros and zero quality.

## Scriptable Objects

**RecipeDatabase.cs** - The master list of every recipe, ingredient, and appliance, plus the finder methods.
> Finders log a message and return null when nothing matches. There's a commented out generic `FindWithID` that used to switch on the first letter of the ID (R for recipe, I for ingredient, A for appliance), which is worth bringing back if ID lookups start happening from more than one place.

**Recipe.cs, Ingredient.cs, Appliance.cs** - Plain data containers.
> Recipe holds base stats and required IDs. Ingredient holds the four stat values plus type, rarity, and cost. Appliance is basically an icon and a name. All read only getters, no logic, which is the right call for this kind of asset.

## Stub Managers

**CustomerSysManager.cs, StaffSysManager.cs, AfterHoursSysManager.cs** - All three just store references right now.
> `Initialize()` only, no behavior yet. They're wired into GameManager so they'll slot in once the systems get built out. Staff and AfterHours both take the bakery manager, Customer takes both bakery and recipe, which hints at where each one is going.

## Referenced but Not Included

Enums like `BakeryPhase`, `Weather`, `IngredientType`, `EventIDs`, and `RecipeRarity` are used throughout but live elsewhere in the project.
