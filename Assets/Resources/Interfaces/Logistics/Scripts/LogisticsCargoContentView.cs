using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogisticsCargoContentView : MonoBehaviour
{
    [Header("ListView")]
    [SerializeField] private ScrollRect ListView;

    [Header("Prefabs")]
    [SerializeField] private ToggleButton Element;


    public TO_CargoBox Box { get; private set; }

    public void LoadBox(TO_CargoBox box)
    {
        ListView.ClearContent();

        Box = box;

        CreateList();
    }

    private void CreateList()
    {
        foreach (var item in Box.Content)
        {
            ToggleButton button = Instantiate( Element );
            button.transform.SetParent( ListView.content, false );
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.Name;
        }
    }
}
