using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalNavigationRadar : MonoBehaviour
{
    [SerializeField] private GameObject ContactPrefab;

    private Dictionary<SolarSystemBody, GameObject> Contacts = new Dictionary<SolarSystemBody, GameObject>();

    private void Start()
    {
        ShipHandler.Instance.ActiveShip.Radar.OnContactAdded += OnContactAdded;
        ShipHandler.Instance.ActiveShip.Radar.OnContactRemoved += OnContactRemoved;

        foreach (var body in ShipHandler.Instance.ActiveShip.Radar.Contacts)
        {
            OnContactAdded(body);
        }
    }

    private void OnContactAdded( SolarSystemBody body )
    {
        var contact = Instantiate(ContactPrefab);
        contact.transform.SetParent(transform, false);
        contact.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = body.RadarInfo();
        Contacts.Add( body, contact );
    }

    private void OnContactRemoved( SolarSystemBody body )
    {
        if (Contacts.ContainsKey(body) == false) return;
        Destroy(Contacts[body]);
        Contacts.Remove(body);
    }

    private void OnDestroy()
    {
        ShipHandler.Instance.ActiveShip.Radar.OnContactAdded -= OnContactAdded;
    }
}