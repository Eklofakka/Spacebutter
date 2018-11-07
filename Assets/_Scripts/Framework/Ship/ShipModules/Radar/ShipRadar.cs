using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRadar
{
    public int Range { get; set; } = 64;

    public List<SolarSystemBody> Contacts = new List<SolarSystemBody>();

    public Action<SolarSystemBody> OnContactAdded { get; set; } = delegate { };
    public Action<SolarSystemBody> OnContactRemoved { get; set; } = delegate { };

    public void Scan( SolarSystem system )
    {
        RemoveContacts();

        AddContacts(system);
    }

    private void AddContacts(SolarSystem system)
    {
        bool withinRange;
        float distance;
        Ship playerShip = ShipHandler.Instance.ActiveShip;

        foreach (var stargate in system.Stargates)
        {
            distance = Vector2.Distance(playerShip.Position.Solar, stargate.Position);

            withinRange = distance <= Range;

            if (withinRange && Contacts.Contains(stargate) == false)
            {
                AddContact(stargate);
                OnContactAdded(stargate);
            }
        }

        foreach (var planet in system.Planets)
        {
            distance = Vector2.Distance(playerShip.Position.Solar, planet.Position);

            withinRange = distance <= Range;

            if (withinRange && Contacts.Contains(planet) == false)
            {
                AddContact(planet);
                OnContactAdded(planet);
            }
        }

        // Look for sun.
        distance = Vector2.Distance(playerShip.Position.Solar, system.Sun.Position);

        withinRange = distance <= Range;

        if (withinRange && Contacts.Contains(system.Sun) == false)
        {
            AddContact(system.Sun);
            OnContactAdded(system.Sun);
        }
    }

    private void RemoveContacts()
    {
        bool withinRange;
        float distance;
        Ship playerShip = ShipHandler.Instance.ActiveShip;

        List<SolarSystemBody> toBeRemoved = new List<SolarSystemBody>();

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
        if (Contacts.Contains(body) == false)
            Contacts.Add( body );
    }
}
