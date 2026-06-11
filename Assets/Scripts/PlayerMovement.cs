using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField]private int shellUpgrade = 1;
    [SerializeField]private int speedUpgrade = 1; 
    [SerializeField] private int SizeUpgrade = 1;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private int shellCounter = 0;
    private float slow = .1f;
    private float speed = .5f;
    private float scaleX = 1;
    private float scaleY = 1f;
    public TMP_Text counterText;
    private System.Random Rand = new System.Random();
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        MoveSideways();
    }

    public void moreSize()
    {
        if (shellCounter > 99)
        {
            SizeUpgrade += 1;
            scaleX += 0.5f;
            scaleY += 0.5f;
            transform.localScale = new Vector3(scaleX, scaleY, 0);
            shellCounter -= 100;
        }

        counterText.text = "Shells: " + shellCounter;
    }

    public void moreSpeed()
    {
        if (shellCounter > 19)
        {
            speedUpgrade += 1;
            moveSpeed += speed;
            shellCounter -= 20;
            
        }
        
        counterText.text = "Shells: " + shellCounter;
    }

    public void moreShell()
    {
        if (shellCounter > 9)
        {
            shellUpgrade += 1;
            shellCounter -= 10;
            moveSpeed -= slow;
        }

        counterText.text = "Shells: " + shellCounter;
    }


    public void Move(InputAction.CallbackContext context)
    {
       moveInput = context.ReadValue<Vector2>();
    }

    public void MoveSideways()
    {
        bool movingSideways = moveInput.x != 0;

        if(movingSideways)
        {
            rb.linearVelocity = moveInput * moveSpeed;
        }
        else
        {
            rb.linearVelocity = new Vector2(0,0);
        }

        //rb.linearVelocity = moveInput * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shell") && collision.gameObject.activeSelf)
        {
            collision.gameObject.SetActive(false);
            Invoke("playSound", 0);
            shellCounter += shellUpgrade;
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
