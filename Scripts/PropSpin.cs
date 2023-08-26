using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpin : MonoBehaviour
{
    // Initializes speed variable and sets it to 1 RPM
    private float rotationSpeed = 360.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This rotates the propeller
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
