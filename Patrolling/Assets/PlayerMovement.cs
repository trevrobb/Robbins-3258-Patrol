using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private bool grounded;
    private CharacterController controller;
    [SerializeField] GameObject feet;
    float gravityY;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    bool isJumping;
    void Start()
    {
        controller = this.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.E))
        {
            this.transform.Rotate(new Vector3(0, .5f, 0) * -1 );
        }


        float verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed; 
        float horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        if (Physics.Raycast(transform.position, -Vector3.up, 14f))
        {
            grounded = true;
            gravityY = 0;
        }
        else { grounded = false; }

        if (!grounded)
        {
            gravityY = Physics.gravity.y * Time.deltaTime;

        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            isJumping = true;
            gravityY = Mathf.Sqrt(jumpForce * -2 * Physics.gravity.y);
            
        }
        if (isJumping)
        {
            if (grounded)
            {
                isJumping = false;
            }
        }
        

        Vector3 verticalMovement = verticalInput * transform.forward ; 
        Vector3 horizontalMovement = horizontalInput * transform.right;
        controller.Move(verticalMovement);
        controller.Move(horizontalMovement);
        controller.Move(new Vector3(0, gravityY, 0));
    }


    private void FixedUpdate()
    {
    }
        private void playerMovement(float vertical, float horizontal, float gravity, bool jumping)
        {




            Vector3 forward = Vector3.forward;
            Vector3 right = Vector3.right * transform.rotation.y;

            




        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.CompareTag("VisionCone"))
        {
            RandomPath.instance.visionCone = true;
        }
    }
}
