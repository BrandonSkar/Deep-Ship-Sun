using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public bool IsMenuOpen { get; private set; }

    void Awake() => Instance = this;

    public void OpenMenu()
    {
        IsMenuOpen = true;
        // show menu
    }

    public void CloseMenu()
    {
        IsMenuOpen = false;
        // hide menu
    }
}
