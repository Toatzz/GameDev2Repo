using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
// Start is called before the first frame update
{
    public abstract void EnterState(PlayerStateMachine state_machine);
    public abstract void ExitState(PlayerStateMachine state_machine);
    public abstract void UpdateState(PlayerStateMachine state_machine);
    public abstract void FixedUpdateState(PlayerStateMachine state_machine);
    public Vector3 Accelerate(Vector3 wish_dir, Vector3 current_velocity, float accel, float max_speed)
    {
        //Vector 3 projection fo current velocity onto wish dir. the speed the player is going
        float proj_speed = Vector3.Dot(current_velocity, wish_dir);
        float accel_speed = accel * Time.deltaTime; // the acceleration component to add
        if (proj_speed + accel_speed > max_speed)
        {
            // truncate accelerated velocity if needed
            accel_speed = max_speed - proj_speed;

        }

        //return new speed
        return current_velocity + (wish_dir * accel_speed);
    }




}
