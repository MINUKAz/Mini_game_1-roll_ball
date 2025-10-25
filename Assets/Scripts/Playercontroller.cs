using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Playercontroller : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0; 
    private int Score;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        Score = 0; 
        SetCountText();
        winTextObject.SetActive(false);
 
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
        if (Score >= 12)
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject); 
            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }

}
