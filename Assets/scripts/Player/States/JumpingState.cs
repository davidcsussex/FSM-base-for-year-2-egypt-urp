
using Unity.Android.Gradle.Manifest;
using UnityEngine;
namespace Player
{
    public class JumpingState : State
    {

        enum JumpType
        {
            StandJump,
            RunJump
        }

        JumpType jumpType;
        bool jumpStarted;

        // constructor
        public JumpingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();


            player.anim.SetBool("RunJump", false);
            player.anim.SetBool("StandJump", false);

            //if mag 0 or near zero, need to add a standing jump
            Debug.Log("player mag=" + player.GetMovement().magnitude);

            if (player.GetMovement().magnitude >= 0.1f)
            {
                jumpType = JumpType.RunJump;
                player.anim.SetBool("RunJump", true);
                Debug.Log("Doing runjump from jump");
                player.velocity.y = 6;

            }
            else
            {
                jumpType = JumpType.StandJump;
                player.anim.SetBool("StandJump", true);
                player.moveSpeed = 0;
                player.velocity.y = 0;

            }

            jumpStarted = false;


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

            DoJump();

        }

        public void JumpStarted()
        {
            player.velocity.y = 6;
            Debug.Log("Jump started");
            jumpStarted= true;
        }


        public void JumpEnded()
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

            if( player.CheckForFall() == true )
            {
                sm.ChangeState(player.fallState);
            }

            if (player.rb.linearVelocity.y < 0)
            {
                //if (player.IsGrounded() == true)
               //   return true;
            }
                //return false;
        }

        void DoJump()
        {
            float gravity = player.gravity;
            if (jumpType == JumpType.StandJump)
            {
                if (player.velocity.y < 2)
                {
                    gravity *= 3;
                }
            }

            player.velocity.y += gravity * Time.deltaTime;

            player.cc.Move((player.moveDir * player.moveSpeed + player.velocity) * Time.deltaTime);

            if (player.cc.isGrounded && jumpStarted )
            {
                //Debug.Log("yv=" + player.velocity.y);
                player.velocity.y = -3;
                sm.ChangeState(player.standingState);

            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}