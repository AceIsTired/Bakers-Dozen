using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BakeryState
{
    // base values that a game state (bakery state) needs to keep track of
    private int totalDays, money, reputation;
    private (int hour, int minute) currentTime;
    private BakeryPhase currentPhase;
    private Weather currentWeather;
    private List<EventIDs> currentEventIDs;
    private List<string> currentStaffIDs;
    private List<string> heldRecipeIDs;
    private Dictionary<string, int> ingredientStock;


    // set public read only getter properties for other functions
    public int TotalDays => totalDays;
    public (int Hour, int Minute) CurrentTime => currentTime;
    public int Money => money;
    public int Reputation => reputation;
    public BakeryPhase BakeryPhase => currentPhase;
    public Weather CurrentWeather => currentWeather;
    public List<EventIDs> CurrentEventIDs => currentEventIDs;
    public List<string> CurrentStaffIDs => currentStaffIDs;
    public List<string> HeldRecipeIDs => heldRecipeIDs;
    public Dictionary<string, int> IngredientStock => ingredientStock;


    // bakery state constructor
    public BakeryState()
    {
        heldRecipeIDs = new List<string>();
        ingredientStock = new Dictionary<string, int>();
        currentEventIDs = new List<EventIDs>();
        currentStaffIDs = new List<string>();
    }


    // public setters
    public void ChangeTotalDays(int amount)
    {
        this.totalDays += amount;
    }
    public void SetTotalDays(int amount)
    {
        this.totalDays = amount;
        Debug.Log($"Set total days to: {amount}");
    }


    public void ChangeMoney(int amount)
    {
        this.money += amount;
    }
    public void SetMoney(int amount)
    {
        this.money = amount;
        Debug.Log($"Set money to: {amount}");
    }


    public void ChangeReputation(int amount)
    {
        this.reputation += amount;
    }
    public void SetReputation(int amount)
    {
        this.reputation = amount;
        Debug.Log($"Set reputation to: {amount}");
    }


    // Time functions assume a full calendar day is 24 hours (1440 minutes), and the bakery day increments in 10 minute intervals.
    public void SetTime(int hour, int minute)
    {
        // check to see if trying to set to value outside of the 24 hour range
        if((hour > 24 || hour < 0) || (minute > 1440 || minute < 0)){Debug.Log("Must be between 00:00 and 23:50!");} // ADD BREAK

        // get the properly formatted time (converted), then set
        (int fHour, int fMinute) inputTime = GetFTime(hour, minute);

        this.currentTime.hour = inputTime.fHour;
        this.currentTime.minute = inputTime.fMinute;
    }
    public void ChangeTime(int hour, int minute) // Can accept negative values, sets to the sum of currentTime and the given time offset
    {
        (int fHour, int fMinute) inputOffset = GetFTime(hour + currentTime.hour, minute + currentTime.minute);

        this.currentTime.hour = inputOffset.fHour;
        this.currentTime.minute = inputOffset.fMinute;
    }

    // converts time into proper formatting (minutes and hours rollover on proper intervals)
    public (int, int) GetFTime(int hour, int minutes)
    {
        float temp;

        temp = minutes + (hour * 60);
        temp -= temp % 10;

        int newHour = (int)(math.floor(temp / 60));
        int newMinutes = (int)(temp % 60);

        if(newHour >= 24){return (23, 50);} // time is independent of totalDays, so anything 24 or over is clamped to 23:50 and bakery time will auto end (if active)

        return (newHour, newMinutes);
    }

    public void SetPhase(BakeryPhase phase)
    {
        this.currentPhase = phase;
    }

}
