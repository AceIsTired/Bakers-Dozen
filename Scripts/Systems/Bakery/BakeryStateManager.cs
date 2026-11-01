using UnityEngine;

public class BakeryStateManager : MonoBehaviour
{
    (int hour, int min) preOpenTime, openTime, closingTime;
    int closedCutoff;
    float currentTimeTick, tickSpeed = 1.5f;

    public BakeryState State {get; private set;}

    public void Initialize()
    {
        State = new BakeryState();
        State.SetTime(6, 0);
        State.SetPhase(BakeryPhase.PreOpen);
        currentTimeTick = 0f;
        preOpenTime = (6, 0);
        openTime = (9, 0);
        closingTime = (18, 0);
        closedCutoff = 19;

        Debug.Log("Initialized Day State\n");
    }


    void Update()
    {
        DoTimeTick();
    }

    public void DoTimeTick()
    {
        if(State == null || State.BakeryPhase == BakeryPhase.Closed || State.BakeryPhase == BakeryPhase.AfterHours){return;} // should not tick if null, closed, or away

        currentTimeTick += Time.deltaTime;
        if(currentTimeTick >= tickSpeed)
        {
            currentTimeTick -= tickSpeed;
            State.ChangeTime(0, 10);
            CheckPhase();

            BSMPrintDebugState();
        }

    }

    public void CheckPhase()
    {
        (int hour, int min) cur_time = State.CurrentTime;

        bool isPreOpen = (cur_time.hour >= preOpenTime.hour) && (cur_time.hour < openTime.hour);
        bool isOpen = (cur_time.hour >= openTime.hour) && (cur_time.hour < closingTime.hour);
        bool isClosing = (cur_time.hour >= closingTime.hour) && (cur_time.hour < closedCutoff);
        bool isClosed = cur_time.hour >= closedCutoff;


        if(isPreOpen && State.BakeryPhase != BakeryPhase.PreOpen)
        {
            State.SetPhase(BakeryPhase.PreOpen);
            Debug.Log("State set to PreOpen (Wasn't originally Set!!!)");
        }
        else if(isOpen && State.BakeryPhase != BakeryPhase.Open)
        {
            State.SetPhase(BakeryPhase.Open);
            Debug.Log("State set to Open");

        }
        else if(isClosing && State.BakeryPhase != BakeryPhase.Closing)
        {
            State.SetPhase(BakeryPhase.Closing);
            Debug.Log("State set to Closing");
        }
        else if (isClosed && State.BakeryPhase != BakeryPhase.Closed)
        {
            State.SetPhase(BakeryPhase.Closed);
            Debug.Log("State set to Closed");
        }
    }

    public void BSMPrintDebugState()
    {
        int h = State.CurrentTime.Hour;
        int m = State.CurrentTime.Minute;
        Debug.Log($"Current Time: {h:D2}:{m:D2}\nCurrent Phase: {State.BakeryPhase}\n");
    }
}
