using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CI_Logistics : MonoBehaviour
{
    [Header("Contents")]
    [SerializeField] private Transform TOPCargoBoxesContent;
    [SerializeField] private Transform BOTTOMCargoBoxesContent;

    [SerializeField] private Transform TOPCargoBoxContentContent;
    [SerializeField] private Transform BOTTOMCargoBoxContentContent;


    [Header("ListElements")]
    [SerializeField] private GameObject CargoBoxesListElement;
    [SerializeField] private GameObject CargoBoxContentListElement;

    [Header("Fields")]
    [SerializeField] private TextMeshProUGUI TotalBoxes;
    [SerializeField] private TextMeshProUGUI TotalWeight;

    private void Start()
    {
        TotalBoxes.text = TO_CargoBox.CargoBoxes.Count.ToString();
        TotalWeight.text = CalcTotalWeight().ToString();

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
        foreach (var box in TO_CargoBox.CargoBoxes)
        {
            // TOP LIST
            GameObject obj = Instantiate(CargoBoxesListElement);
            obj.transform.SetParent( TOPCargoBoxesContent, false );

            obj.GetComponent<ToggleButton>().OnClick.AddListener( ( ) => { AddBoxContentToList(box, TOPCargoBoxContentContent); } );

            // BOTTOM LIST
            obj = Instantiate(CargoBoxesListElement);
            obj.transform.SetParent(BOTTOMCargoBoxesContent, false);

            obj.GetComponent<ToggleButton>().OnClick.AddListener(() => { AddBoxContentToList(box, BOTTOMCargoBoxContentContent); });
        }
    }

    private void AddBoxContentToList( TO_CargoBox box, Transform parent )
    {
        foreach (Transform child in parent.transform)
        {
            Destroy( child.gameObject );
        }

        foreach (string content in box.Content)
        {
            GameObject obj = Instantiate(CargoBoxesListElement);
            obj.transform.SetParent(parent, false);
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = content;
        }
    }
}