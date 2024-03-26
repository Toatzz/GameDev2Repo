using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using TMPro;

public class Gun : MonoBehaviour
{
    //Debug
    public TMP_Text debug_text;

    //Gun Variables
    public GunData gun_data;
    public Camera cam;
    protected Ray ray;

    //Ammo Variables
    protected int ammo_in_clip;

    //Shooting
    protected bool primary_fire_is_shooting = false;
    protected bool primary_fire_hold = false;
    public float shoot_delay_timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        ammo_in_clip = gun_data.ammo_per_clip;
    }

    // Update is called once per frame
    void Update()
    {
        debug_text.text = "Ammo in Clip:" + ammo_in_clip.ToString();
        if (shoot_delay_timer > 0) shoot_delay_timer -= Time.deltaTime; //subtract from timer
        PrimaryFire();

    }
    public void GetPrimaryFireInput(InputAction.CallbackContext context)
    {   // Check for initial button press
        if (context.phase == InputActionPhase.Started)
        {
            primary_fire_is_shooting = true;
        }
        //Check if is automatic
        if (gun_data.automatic)
        {
            //Check if hold interaction was complete
            if (context.interaction is HoldInteraction && context.phase == InputActionPhase.Performed)
            {
                primary_fire_hold = true;
            }
        }
        //Check if button was released
        if (context.phase == InputActionPhase.Canceled)
        {
            primary_fire_is_shooting = false;
            primary_fire_hold = false;
        }
    }
    public void GetSecondaryFireInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started) SecondaryFire();

    }
    protected virtual void PrimaryFire()
    {

    }
    protected virtual void SecondaryFire()
    {

    }
}
