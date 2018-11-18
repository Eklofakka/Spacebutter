using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToggleButtonGroup : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private bool _Multiple = true;
    public bool Multiple
    {
        get { return _Multiple; }
        set
        {
            _Multiple = value;

            if (value == false)
                OnMultipleSetToFalse();
        }
    }

    public List<ToggleButton> Buttons { get; set; } = new List<ToggleButton>();

    public void AddButton( ToggleButton button )
    {
        if (Buttons.Contains(button)) return;

        Buttons.Add( button );
    }

    public void RemoveButton( ToggleButton button )
    {
        Buttons.Remove( button );
    }

    public void OnToggledChanged( ToggleButton button )
    {
        if (Multiple) return;

        foreach (ToggleButton _button in Buttons)
        {
            if (button == _button) continue;

            _button.SetToggle(false, false);
        }
    }

    public List<ToggleButton> ToggledButtons()
    {
        return Buttons.Where(b => b.Toggled).ToList();
    }

    private void OnMultipleSetToFalse()
    {
        bool oneToggled = false;

        foreach (var button in Buttons)
        {
            if ( oneToggled == true )
            {
                button.SetToggle( false, false );
                continue;
            }

            if (button.Toggled)
                oneToggled = true;
        }
    }
}