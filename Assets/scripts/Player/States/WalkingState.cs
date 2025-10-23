
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
            player.anim.SetBool("RunJump", false);
            player.anim.SetBool("Walk", true);

            player.isTouchingVehicle = false;
        }

        public override void Exit()
        {
            base.Exit();
            player.anim.SetBool("Run", false);
            player.anim.SetBool("Walk", false);
            Debug.Log("set walk to false");
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
                return;
            }

            if( player.CanEnterVehicle() && player.reEnterVehicleTimer < 0 )
            {
                sm.ChangeState(player.enterCarState);
                return;
            }


            if (player.CheckForSprint())
            {
                player.anim.SetBool("Run", true);
                player.anim.SetBool("Walk", false);
                player.moveSpeed = 25;

            }
            else
            {
                player.anim.SetBool("Run", false);
                player.anim.SetBool("Walk", true);
                Debug.Log("Set walk true");
                player.moveSpeed = 10;

            }
            player.DoRun();


            if ( player.JumpButtonPressed() == true )
            {
                //player.anim.SetBool("Run", false);
                //player.anim.SetBool("Walk", false);

                sm.ChangeState( player.jumpingState );
                Debug.Log("change to jump from walk");
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            
            //Debug.Log("doing run");
        }


    }
}