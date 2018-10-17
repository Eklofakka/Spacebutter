using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalNavigation : MonoBehaviour
{
    public TextMeshProUGUI Galaxy;

    public TextMeshProUGUI Solar;

    private void LateUpdate()
    {
        Galaxy.text = "Galaxy: " + ShipHandler.Instance.ActiveShip.Position.Galaxy;

        Solar.text = "Solar: " + ShipHandler.Instance.ActiveShip.Position.Solar;

        if (Input.GetKeyDown(KeyCode.C))
            Destroy(gameObject);
    }
}
