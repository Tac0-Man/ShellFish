using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class WASDcrash : MonoBehaviour
{
    public GameObject WASDCanvas;


    void Start()
    {
        WASDCanvas.SetActive(false);
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            WASDCanvas.SetActive(true);
            StartCoroutine(crash());
        }
    }

    IEnumerator crash()
    {
        yield return new WaitForSecondsRealtime (1);
        Application.Quit();
    }
}
