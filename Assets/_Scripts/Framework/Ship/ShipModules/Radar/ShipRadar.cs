using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRadar
{
    public int Range { get; set; } = 64;

    public List<SolarSystemBody> Contacts = new List<SolarSystemBody>();

    public Action<SolarSystemBody> OnContactAdded { get; set; } = delegate { Debug.Log( "Contact Added"); };
    public Action<SolarSystemBody> OnContactRemoved { get; set; } = delegate { };

    bool withinRange;
    float distance;
    Ship playerShip;

    bool exitCoroutine = false;
    WaitForSeconds wait = new WaitForSeconds(0.1f);
    WaitForEndOfFrame fWait = new WaitForEndOfFrame();

    List<SolarSystemBody> toBeRemoved = new List<SolarSystemBody>();

    public void Scan( SolarSystem system )
    {
        RemoveContacts();

        AddContacts(system);

        LevelLoaderShip.Instance.StartCoroutine(AddContacts(system));
    }

    private IEnumerator AddContacts(SolarSystem system)
    {
        AIShip ship;
        playerShip = ShipHandler.Instance.ActiveShip;

        yield return wait;

        while (exitCoroutine == false)
        {
            int aiCount = AIShips.Ships.Count;
            for (int i = 0; i < aiCount; i++)
            {
                if (i % 4 == 0)
                    yield return fWait;

                ship = AIShips.Ships[i];
                distance = Vector2.Distance(playerShip.Position.Solar, ship.Positions.Solar);

                withinRange = distance <= Range;

                if (withinRange && Contacts.Contains(ship) == false)
                {
                    //AddContact(ship);
                    //OnContactAdded(ship);
                }
            }

            //foreach (var stargate in system.Stargates)
            //{
            //    distance = Vector2.Distance(playerShip.Position.Solar, stargate.Position);

            //    withinRange = distance <= Range;

            //    if (withinRange && Contacts.Contains(stargate) == false)
            //    {
            //        AddContact(stargate);
            //        OnContactAdded(stargate);
            //    }
            //}
            //yield return wait;

            //foreach (var planet in system.Planets)
            //{
            //    distance = Vector2.Distance(playerShip.Position.Solar, planet.Position);

            //    withinRange = distance <= Range;

            //    if (withinRange && Contacts.Contains(planet) == false)
            //    {
            //        AddContact(planet);
            //        OnContactAdded(planet);
            //    }
            //}
            //yield return wait;

            //// Look for sun.
            //distance = Vector2.Distance(playerShip.Position.Solar, system.Sun.Position);

            //withinRange = distance <= Range;

            //if (withinRange && Contacts.Contains(system.Sun) == false)
            //{
            //    AddContact(system.Sun);
            //    OnContactAdded(system.Sun);
            //}
            //yield return wait;


            //foreach (var aiShip in AIShips.Ships)
            //{
            //    distance = Vector2.Distance(playerShip.Position.Solar, aiShip.Positions.Solar);

            //    withinRange = distance <= Range;

            //    if (withinRange && Contacts.Contains(aiShip) == false)
            //    {
            //        AddContact(aiShip);
            //        OnContactAdded(aiShip);
            //    }
            //}
            yield return wait;
        }
    }

    private void RemoveContacts()
    {
        toBeRemoved.Clear();

        foreach (var contact in Contacts)
        {
            distance = Vector2.Distance(playerShip.Position.Solar, contact.Position);

            withinRange = distance > Range;

            if (withinRange)
            {
                toBeRemoved.Add(contact);
            }
        }

        foreach (var contact in toBeRemoved)
        {
            OnContactRemoved( contact );
            Contacts.Remove( contact );
        }
    }

    private void AddContact( SolarSystemBody body )
    {
        //if (Contacts.Contains(body) == false)
            Contacts.Add( body );
    }
}
