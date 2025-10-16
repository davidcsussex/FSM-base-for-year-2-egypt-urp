
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
            player.velocity.y = 6;

            //if mag 0 or near zero, need to add a standing jump
            Debug.Log("player mag=" + player.GetMovement().magnitude);
            player.anim.SetBool("RunJump", true );
        }

        public override void Exit()
        {
            base.Exit();
            player.anim.SetBool("RunJump", false);
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