using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class ToggleButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private enum Modes { Normal, Toggled, Disabled, Highlighted }
    private Modes Mode { get; set; } = Modes.Normal;


    public bool Toggled { get; private set; } = false;

    private bool _IsEnabled = true;
    public bool IsEnabled
    {
        get { return _IsEnabled; }
        private set
        {
            _IsEnabled = value;

            Mode = value ? Modes.Normal : Modes.Disabled;
        }
    }

    [Header("Toggle Group")]
    public ToggleButtonGroup Group;

    [Header("Transition")]
    public Color C_Normal = Color.white;
    public Color C_MouseOver = Color.white;
    public Color C_Toggled = Color.white;
    public Color C_Disabled = Color.white;

    [Header("Time")]
    public float TransitionSpeed = 20f;

    private Image Image { get; set; }

    private Color TargetColor
    {
        get
        {
            switch( Mode )
            {
                case Modes.Normal: return C_Normal;
                case Modes.Highlighted: return C_MouseOver;
                case Modes.Toggled: return C_Toggled;
                case Modes.Disabled: return C_Disabled;
                default: return Color.cyan;
            }
        }
    }

    [Header("Events")]
    public UnityEvent OnClick;
    public UnityEvent OnToggledChanged;
    public UnityEvent OnGroupToggledChanged;

    private void Start()
    {
        Image = GetComponent<Image>();

        if (Group != null)
            Group.AddButton(this);

        Image.color = C_Normal;
    }

    public void Init( ToggleButtonGroup group )
    {
        Group = group;

        Group.AddButton(this);
    }

    public void SetToggle( bool value, bool report = true )
    {
        print(value);

        Toggled = value;

        Mode = Toggled ? Modes.Toggled : Modes.Normal;

        if (Group == null) return;

        if (report) Group.OnToggledChanged( this );
    }

    private void Update()
    {
        Image.color = Image.color.Lerp( TargetColor, TransitionSpeed );
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if ( Mode != Modes.Disabled && Mode != Modes.Toggled )
        {
            Mode = Modes.Highlighted;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if ( Mode == Modes.Normal || Mode == Modes.Highlighted )
        {
            Mode = Modes.Normal;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Mode == Modes.Disabled) return;

        OnClick.Invoke();

        if ( Mode == Modes.Toggled )
        {
            SetToggle(false);
        }
        else
        {
            SetToggle(true);
        }
    }

    private void OnDestroy()
    {
        if (Group != null)
            Group.RemoveButton(this);

        OnClick.RemoveAllListeners();
    }
}