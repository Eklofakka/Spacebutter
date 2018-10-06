using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CI_Logistics : MonoBehaviour
{
    [Header("ListViews")]
    [SerializeField] private ScrollRect CargoList_TOP;
    [SerializeField] private LogisticsCargoContentView CargoContent_TOP;
    [Space(10)]
    [SerializeField] private ScrollRect CargoList_BOTTOM;
    [SerializeField] private LogisticsCargoContentView CargoContent_BOTTOM;


    [Header("ListElements")]
    [SerializeField] private ToggleButton CargoBoxesListElement;

    [Header("Toolbar")]
    [SerializeField] private Button MoveDown;
    [SerializeField] private Button MoveUp;

    [Header("Fields")]
    [SerializeField] private TextMeshProUGUI TotalBoxes;
    [SerializeField] private TextMeshProUGUI TotalWeight;

    private void Start()
    {
        TotalBoxes.text = TO_CargoBox.CargoBoxes.Count.ToString();
        TotalWeight.text = CalcTotalWeight().ToString();

        MoveDown.onClick.AddListener(() =>
        {
            //var buttons = CargoContent_TOP.GetComponent<ToggleButtonGroup>().ToggledButtons();

            List<CargoBoxContent> l = new List<CargoBoxContent>();

            l.Add( CargoContent_TOP.Box.Content[0] );
            CargoContent_TOP.Box.Content.RemoveAt(0);

            if (CargoBoxTransaction.Move( CargoContent_TOP.Box, CargoContent_BOTTOM.Box, l ) == CargoBoxTransaction.Result.Success)
            {
                CargoContent_TOP.LoadBox(CargoContent_TOP.Box);
                CargoContent_BOTTOM.LoadBox(CargoContent_BOTTOM.Box);
            }

            //List<string> contentToBeMoved = CargoContent_TOP.Box.Content.

        });

        AddBoxesToList();
    }

    private int CalcTotalWeight()
    {
        int tot = 0;

        foreach (var box in TO_CargoBox.CargoBoxes)
        {
            tot += box.Weight;
        }

        return tot;
    }

    private void AddBoxesToList()
    {
        CargoList_TOP.ClearContent();

        foreach (var box in TO_CargoBox.CargoBoxes)
        {
            // TOP LIST
            ToggleButton obj = Instantiate(CargoBoxesListElement);
            obj.transform.SetParent(CargoList_TOP.content, false );
            obj.Init( CargoList_TOP.GetComponent<ToggleButtonGroup>() );
            obj.GetComponent<ToggleButton>().OnClick.AddListener( ( ) => { CargoContent_TOP.LoadBox(box); } );

            // BOTTOM LIST
            obj = Instantiate(CargoBoxesListElement);
            obj.transform.SetParent(CargoList_BOTTOM.content, false);
            obj.Init(CargoList_BOTTOM.GetComponent<ToggleButtonGroup>());
            obj.GetComponent<ToggleButton>().OnClick.AddListener(() => { CargoContent_BOTTOM.LoadBox(box); });
        }
    }
}