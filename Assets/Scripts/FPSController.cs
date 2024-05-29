using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;

    private float gravityMultiplier = 3.0f;
    private float velocity = 20f;
    public float jumpPower = 7f;
    public float gravity = -9.81f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;
    CharacterController characterController;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        #region Handles Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? (walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = 0;




        // if(characterController.isGrounded && velocity<0){
        //     velocity=-1.0f;

        // }else{
        // velocity+=gravity*gravityMultiplier*Time.deltaTime;
        // }

                // velocity+=gravity*gravityMultiplier*Time.deltaTime;

        if (canMove)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rotationX-=10;
                // playerCamera.transform.localRotation = Quaternion.Euler(0, rotationX, 0);
                // transform.rotation *= Quaternion.Euler(0, rotationX, 0);
                transform.Rotate(-Vector3.up * 100 * Time.deltaTime);
                
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // rotationX+=10;
                // transform.rotation *= Quaternion.Euler(0, rotationX, 0);
                transform.Rotate(Vector3.up * 100 * Time.deltaTime);
                // playerCamera.transform.localRotation = Quaternion.Euler(0, , 0);
            }
        }

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY) + transform.TransformDirection(Vector3.down)*velocity;

        characterController.Move(moveDirection * Time.deltaTime);
        #endregion

        
        

        
    }
}
