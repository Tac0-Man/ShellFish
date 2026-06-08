using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject shopCanvas;
   
    void Start()
    {
        menuCanvas.SetActive(false);
        shopCanvas.SetActive(false);
    }

   
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            menuCanvas.SetActive(!menuCanvas.activeSelf);
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            shopCanvas.SetActive(!shopCanvas.activeSelf);
        }
    }
}
