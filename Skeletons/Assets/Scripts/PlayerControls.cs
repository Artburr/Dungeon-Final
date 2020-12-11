using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Vector3 playerStartPosition;
    public GameObject winScreen;

    public float speed;

    private Rigidbody2D rb;

    private Vector2 moveVelocity;

    private bool allowMovement = false;
    public bool gameHasStarted = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ToggleCharacterMovement(bool _bool)
    {
        allowMovement = _bool;
    }

    public void GameHasStarted()
    {
        ToggleCharacterMovement(true);
        gameHasStarted = true;
    }

    public void OnGameReset()
    {
        ToggleCharacterMovement(false);
        gameHasStarted = false;
    }

    void Update()
    {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        if (allowMovement == true)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
    }

    private void OnWin()
    {
        ToggleCharacterMovement(false);
        gameObject.transform.position = playerStartPosition;
        Debug.Log("You Win!");
        winScreen.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boss")
        {
            OnWin();
        }
    }
}
