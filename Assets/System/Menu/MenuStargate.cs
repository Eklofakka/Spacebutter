using UnityEngine;
using UnityEngine.UI;

public class MenuStargate : MenuBase
{
    [SerializeField] private Button JumpButton;

    private void Start()
    {
        SetupButtons();
    }

    private void SetupButtons()
    {
        JumpButton.onClick.AddListener(JumpButton_OnClick);
    }

    private void JumpButton_OnClick()
    {
        OnClose( new MenuReturn( Return.Yes ) );

        CloseWindow();
    }

    private void CloseWindow()
    {
        OnClose = null;

        Destroy( gameObject );
    }
}