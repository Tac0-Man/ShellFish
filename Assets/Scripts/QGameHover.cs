using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QGameHover : MonoBehaviour
{
    [SerializeField]private int waitTime = 4;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Quit") && collision.gameObject.activeSelf)
        {
            StartCoroutine(StartGame(collision, waitTime));
        }
    }

    IEnumerator StartGame (Collider2D collision, int time)
    {
       yield return new WaitForSeconds (time);
       Application.Quit();
    }

}
