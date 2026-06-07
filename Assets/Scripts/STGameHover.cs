using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STGameHover : MonoBehaviour
{
    [SerializeField]private int waitTime = 4;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Start") && collision.gameObject.activeSelf)
        {
            StartCoroutine(StartGame(collision, waitTime));
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        StopAllCoroutines();
    }

    IEnumerator StartGame (Collider2D collision, int time)
    {
       yield return new WaitForSeconds (time);
       SceneManager.LoadScene(1);
    }

}
