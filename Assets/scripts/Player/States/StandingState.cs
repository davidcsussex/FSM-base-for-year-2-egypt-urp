
using UnityEngine;
namespace Player
{
    public class StandingState : State
    {


        // constructor
        public StandingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();

            //player.anim.SetBool("Run", false);
            //player.anim.SetBool("Walk", false);

        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (player.CheckForMovement() == true)
            {
                sm.ChangeState(player.walkingState);
            }

            if(player.ShootButtonPressed() )
            {
                sm.ChangeState(player.shootingState);
            }

            if (player.JumpButtonPressed() == true)
            {
                sm.ChangeState(player.jumpingState);
            }

            if( player.CheckForFall() == true )
            {
                sm.ChangeState(player.fallState);
            }

            //player.anim.SetBool("Run", false);
            //player.anim.SetBool("Walk", false);

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}