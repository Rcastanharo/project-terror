using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    Animator animator;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSensitivity = 3f;

    float crossHairRange = 50f;


    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float CameraUpAndDownRotation = 0f;
    private float CurrentCameraUpAndDownRotation = 0f;

    private Rigidbody rb;


    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {


        //refactored movement script to a better view 03/24/2021
        Movement();

        //Temporary for open inventory
        if (Input.GetKeyDown(KeyCode.I))
        {

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            if (Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

        }

        if (Input.GetKeyDown(KeyCode.P))
        {

            PauseButtonPressed();

        }
    }

    //runs per physics iteration
    private void FixedUpdate()
    {
        //if (velocity != Vector3.zero)
        //{
        //    rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);


        //}

        //rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));


    }


    #region Player movements
    void Movement()
    {
        //Calculate movement veloc,ty as a 3d vector
        float _xMovement = Input.GetAxis("Horizontal");
        float _zMovement = Input.GetAxis("Vertical");

        Vector3 _movementHorizontal = transform.right * _xMovement;
        Vector3 _movementVertical = transform.forward * _zMovement;

        //Final movement velocty vector
        Vector3 _movementVelocity = (_movementHorizontal + _movementVertical).normalized * speed;

        //Apply movement
        Move(_movementVelocity);


        //calculate rotation as a 3D vector for turning around.
        float _yRotation = Input.GetAxis("Mouse X");
        Vector3 _rotationVector = new Vector3(0, _yRotation, 0) * lookSensitivity;


        //Apply rotation
        Rotate(_rotationVector);



        //Calculate look up and down camera rotation
        float _cameraUpDownRotation = Input.GetAxis("Mouse Y") * lookSensitivity;

        //Apply rotation
        RotateCamera(_cameraUpDownRotation);
    }

    void Move(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
    }

    void Rotate(Vector3 rotationVector)
    {
        rotation = rotationVector;

    }

    void RotateCamera(float cameraUpAndDownRotation)
    {
        CameraUpAndDownRotation = cameraUpAndDownRotation;
    }



    #endregion

    void PauseButtonPressed()
    {
        GameObject UI_GameManager = GameObject.Find("UI_GameManager");
        UI_GameManager other = (UI_GameManager) UI_GameManager.GetComponent(typeof(UI_GameManager));
        other.EnableDisablePauseScreen();
        //UI_GameManager.EnableDisable
        
    }

}
