using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CI_Logistics : MonoBehaviour
{
    [Header("Contents")]
    [SerializeField] private Transform CargoBoxesContent;
    [SerializeField] private Transform CargoBoxContentContent;

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
            GameObject obj = Instantiate( CargoBoxContentListElement );
            obj.transform.SetParent( CargoBoxesContent, false );

            obj.GetComponent<Button>().onClick.AddListener( ( ) => { AddBoxContentToList(box); } );
        }
    }

    private void AddBoxContentToList( TO_CargoBox box )
    {
        foreach (Transform child in CargoBoxContentContent.transform)
        {
            Destroy( child.gameObject );
        }

        foreach (string content in box.Content)
        {
            GameObject obj = Instantiate(CargoBoxContentListElement);
            obj.transform.SetParent(CargoBoxContentContent, false);
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = content;
        }
    }
}