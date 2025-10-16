
using UnityEngine;

namespace Player
{
    public class WalkingState : State
    {
        Vector3 mov;

        // constructor
        public WalkingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();

            player.anim.SetBool("Run", false);
            player.anim.SetBool("Walk", false);

            if (player.RunButtonPressed())
            {
                player.anim.SetBool("Run", true);
            }
            else
            {
                player.anim.SetBool("Walk", true);
            }
            player.isTouchingVehicle = false;
        }

        public override void Exit()
        {
            base.Exit();
            player.anim.SetBool("Run", false);
            player.anim.SetBool("Walk", false);
            Debug.Log("set to false");
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            mov = player.GetMovement();

            if (player.CheckForMovement() == false)
            {
                sm.ChangeState(player.standingState);
            }

            if( player.CanEnterVehicle() && player.reEnterVehicleTimer < 0 )
            {
                sm.ChangeState(player.enterCarState);
                return;
            }


            if (player.RunButtonPressed())
            {
                player.anim.SetBool("Run", true);
                player.anim.SetBool("Walk", false);
                player.DoRun(true);

            }
            else
            {
                player.anim.SetBool("Run", false);
                player.anim.SetBool("Walk", true);
                player.DoRun(false);
                Debug.Log("set walk true");


            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            
            //Debug.Log("doing run");
        }


    }
}