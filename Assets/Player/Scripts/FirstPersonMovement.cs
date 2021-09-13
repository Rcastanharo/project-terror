using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonMovement : MonoBehaviour
{
    /* Info de stamina
    [Header("Stamina Stats")]
    public float playerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f;
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool weAreSprinting = true;

    [Header("Regeneration")]
    [Range(0, 50)] [SerializeField] private float staminaDrain = 0.5f;
    private float staminaRegen = 0.5f;

    [Header("Speed")]
    [SerializeField] private int slowedRunspeed = 4;
    [SerializeField] private int normalRunspeed = 8;

    [Header("UI Elements")]
    //[SerializeField] private staminaProgressUI = null;
    //[SerializeField] private CanvasGroup = null;*/


    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            //weAreSprinting = true;
            //playerStamina -= staminaDrain * Time.deltaTime;
            //UpdateStamina(1);
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        /*if (!weAreSprinting)
        {
            if (playerStamina <= maxStamina - 0.01)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                //começa a regenerar
                if (playerStamina >= maxStamina)
                    hasRegenerated = true;
            }

        }

        void UpdateStamina(int Value)
        {
            StaminaBar_Slider.fillAmount = playerStamina / maxStamina;
            if (Value == 0)
            {
                StaminaBar_Group.alpha = 0;
            }
            else
            {
                StaminaBar_Group.alpha = 1;
            }
        }*/


        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }

    void PauseButtonPressed()
    {
        GameObject UI_GameManager = GameObject.Find("UI_GameManager");
        UI_GameManager other = (UI_GameManager)UI_GameManager.GetComponent(typeof(UI_GameManager));
        other.EnableDisablePauseScreen();
        //UI_GameManager.EnableDisable

    }

}