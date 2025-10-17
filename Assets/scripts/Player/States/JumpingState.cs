
using UnityEngine;
namespace Player
{
    public class JumpingState : State
    {


        // constructor
        public JumpingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();

            //if mag 0 or near zero, need to add a standing jump
            Debug.Log("player mag=" + player.GetMovement().magnitude);

            if (player.GetMovement().magnitude >= 0.1f)
            {
                player.anim.SetBool("RunJump", true);
                player.velocity.y = 6;

            }
            else
            {
                player.anim.SetBool("StandJump", true);
                player.moveSpeed = 0;
                player.velocity.y = 0;


            }
        }

        public override void Exit()
        {
            base.Exit();
            player.anim.SetBool("RunJump", false);
            player.anim.SetBool("StandJump", false);
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            player.DoJump();

            if( player.IsGroundedCC() )
            {
                //sm.ChangeState(player.standingState);

            }
            //if( JumpEnded() )
        }

        public bool JumpEnded()
        {
            if( player.CheckForMovement() )
            {
                //player is stil holding stick after ending jump
                sm.ChangeState(player.walkingState);
            }
            else
            {
                sm.ChangeState(player.standingState);

            }

            if (player.rb.linearVelocity.y < 0)
            {
                if (player.IsGrounded() == true)
                    return true;
            }
                return false;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}