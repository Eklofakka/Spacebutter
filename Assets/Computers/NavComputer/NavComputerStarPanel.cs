using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NavComputerStarPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI xShip;
    [SerializeField] private TextMeshProUGUI yShip;

    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI xStar;
    [SerializeField] private TextMeshProUGUI yStar;

    [SerializeField] private TextMeshProUGUI Distance;
    [SerializeField] private TextMeshProUGUI Time;

    [SerializeField] private TextMeshProUGUI Celestials;
    [SerializeField] private TextMeshProUGUI Habitable;

    private SolarSystem SolarSystem;
    private Transform StarIcon;

    public static NavComputerStarPanel Inst;

    private void Awake()
    {
        Inst = this;
    }

    private void Update()
    {
        xShip.text = "X: " + Ship.MainShip.Position.x;
        yShip.text = "Y: " + Ship.MainShip.Position.y;
    }

    public static void SetStar( Transform icon, SolarSystem system )
    {
        Inst.StarIcon = icon;

        //Inst.xShip.text = "X: " + Ship.MainShip.Position.x;   
        //Inst.yShip.text = "Y: " + Ship.MainShip.Position.y;

        Inst.Name.text = "Name: " + system.Name;
        Inst.xStar.text = "X: " + system.Position.x;
        Inst.yStar.text = "Y: " + system.Position.y;

        Inst.Distance.text = "Distance: " + Vector2Int.Distance( Ship.MainShip.Position, system.Position );
        Inst.Time.text = "Time: n/a";

        Inst.Celestials.text = "Celestials: " + system.Planets.Count;
        Inst.Habitable.text = "Habitable: Unknown";
    }
}
