using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private string tagDetect;
    [SerializeField] private int waitTime = 4;
    public UnityEvent detected;
    public UnityEvent playerEnter;
    public UnityEvent playerLeft;



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagDetect) && collision.gameObject.activeSelf)
        {
            StartCoroutine(DetectAfter(collision, waitTime));
            playerEnter.Invoke();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        
         if (collision.CompareTag(tagDetect) && collision.gameObject.activeSelf)
        {
            playerLeft.Invoke();
            StopAllCoroutines();
        }
    }

    IEnumerator DetectAfter (Collider2D collision, int time)
    {
       yield return new WaitForSeconds (time);
       detected.Invoke();
       
    }

    


}
