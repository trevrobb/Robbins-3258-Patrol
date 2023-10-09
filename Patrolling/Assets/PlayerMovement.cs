using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private bool grounded;
    private CharacterController controller;
    [SerializeField] GameObject feet;
    float gravityY;
    void Start()
    {
        controller = this.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Physics.CheckSphere(feet.transform.position, .1f, 6))
        {
            grounded = true;
            gravityY = 0;
        }
        else { grounded = false; }

        if (!grounded)
        {
            gravityY = Physics.gravity.y/2;

        }
        playerMovement(verticalInput, horizontalInput, gravityY);
    }
    private void playerMovement(float vertical, float horizontal, float gravity)
    {
        

        Vector3 verticalMovement = Vector3.forward * vertical;
        Vector3 horizontalMovement = Vector3.right * horizontal;


        controller.Move(new Vector3(verticalMovement.x, gravity, verticalMovement.z));
        controller.Move(new Vector3(horizontalMovement.x, gravity, horizontalMovement.z));




    }
}
