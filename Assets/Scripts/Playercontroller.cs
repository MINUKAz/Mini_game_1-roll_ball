using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Playercontroller : MonoBehaviour
{
    public Game_Manager Manager;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0; 
    private int Score;
    public TextMeshProUGUI countText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        Score = 0; 
        SetCountText();
 
    }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x; 
        movementY = movementVector.y; 

    }  

    private void FixedUpdate() 
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed); 
    
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Pickup")) 
        {
           other.gameObject.SetActive(false);
           Score = Score + 1;
           SetCountText();
        }
    
    }

    void SetCountText() 
    {
        countText.text =  "Score: " + Score.ToString();
        if (Score >= 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            Manager.Completelevel();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject); 
            // Update the winText to display "You Lose!"
            FindAnyObjectByType<Game_Manager>().Endgame();
        }
    }

}
