using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Variable initializations 
    [SerializeField] float speed;
    private const float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] private float horsePower = 0f;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedoText;
    [SerializeField] TextMeshProUGUI tachText;
    [SerializeField] float revSpeed;
    [SerializeField] List<WheelCollider> allWheels;
    

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Retrieve player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = -Input.GetAxis("Vertical");
        if (IsOnGround())
        {
            // Will move the player
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            // Will turn player
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
            revSpeed = Mathf.RoundToInt((speed % 30) * 40);
            speedoText.SetText("Speed: " + speed + "mph");
            tachText.SetText("RPM: " + revSpeed);
        }
    }
    bool IsOnGround()
    {
        int wheelCount = 0;

        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelCount++;
            }
        }
        if(wheelCount == 4)
        {
            return true;
        }
        else { return false; }
    }
}
