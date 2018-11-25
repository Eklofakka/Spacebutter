using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TerminalNavigationWarp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI X;
    [SerializeField] private TextMeshProUGUI Y;
    [SerializeField] private TextMeshProUGUI Distance;
    [SerializeField] private TextMeshProUGUI Angle;
    [SerializeField] private Button Lock;
    public Button Warp;

    private WarpEngine WarpEngine;

    private void Start()
    {
        WarpEngine = ShipHandler.Instance.ActiveShip.WarpEngine;

        WarpEngine.OnTargetPositionChanged += OnWarpTargetChanged;
        WarpEngine.OnBeginSpool += OnBeginSpool;
        WarpEngine.OnLockedChanged += OnLockChanged;

        ShipHandler.Instance.ActiveShip.Position.OnReachedTargetPosition += OnReachedWarpTarget;

        Warp.onClick.AddListener(OnWarpButtonClicked);
        Lock.onClick.AddListener(OnLockButtonClicked);
    }

    public void SetFields(string x, string y, string dist, string angl)
    {
        X.text = x;
        Y.text = y;
        Distance.text = dist;
        Angle.text = angl;
    }

    private void OnWarpTargetChanged()
    {
        X.text = WarpEngine.TargetPosition.x.ToString();
        Y.text = WarpEngine.TargetPosition.y.ToString();
    }

    private void OnLockChanged( bool locked)
    {
        Debug.Log("changed");
        ColorBlock cb = Lock.colors;
        cb.normalColor = locked ? Color.red : Color.green;
        Lock.colors = cb;
    }

    private void OnBeginSpool()
    {
        Warp.interactable = false;
    }

    private void OnReachedWarpTarget()
    {
        Warp.interactable = true;
    }

    private void OnWarpButtonClicked()
    {
        WarpEngine.Warp();
    }

    private void OnLockButtonClicked()
    {
        WarpEngine.ToggleLockTarget();
    }
}
