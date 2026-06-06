using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 7f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private int shellCounter = 0;
    public TMP_Text counterText;
    private System.Random Rand = new System.Random();
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }


    public void Move(InputAction.CallbackContext context)
    {
       moveInput = context.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shell") && collision.gameObject.activeSelf)
        {
            collision.gameObject.SetActive(false);
            Invoke("playSound", 0);
            shellCounter += 1;
            counterText.text = "Shells: " + shellCounter;
            StartCoroutine(Respawn(collision,Rand.Next(2,12)));
        } 
        
    }

    IEnumerator Respawn (Collider2D collision, int time)
    {
        yield return new WaitForSeconds (time);
        collision.gameObject.SetActive(true);
    }

    void playSound()
    {
        
    }
}
