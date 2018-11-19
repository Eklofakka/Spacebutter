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
    [SerializeField] private Button Warp;

    public void SetFields(string x, string y, string dist, string angl)
    {
        X.text = x;
        Y.text = y;
        Distance.text = dist;
        Angle.text = angl;
    }
}
