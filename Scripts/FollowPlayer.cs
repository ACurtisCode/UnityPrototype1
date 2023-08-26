using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Variables initialized
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -7);


    // Update is called once per frame
    void LateUpdate()
    {
        //This follows the player from a distance
        transform.position = player.transform.position + offset;
    }
}
