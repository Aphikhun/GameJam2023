using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rbPlayer;

    [SerializeField] private float moveSpeed = 5f;
    Vector2 movement;
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        rbPlayer.MovePosition(rbPlayer.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
