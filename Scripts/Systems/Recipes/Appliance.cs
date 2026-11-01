using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Appliance", menuName = "Scriptable Objects/Appliance")]
public class Appliance : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] private string applianceName;
    [SerializeField] private string applianceID;


    // public getters
    public Sprite Icon => icon;
    public string Name => applianceName;
    public string ID => applianceID;


}
