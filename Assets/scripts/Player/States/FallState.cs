
using UnityEngine;
namespace Player
{
    public class FallState : State
    {
        // constructor
        public FallState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();


            player.anim.SetBool("RunJump", false);
            player.anim.SetBool("StandJump", false);


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
            DoFall();

        }


        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }


        void DoFall()
        {
            float gravity = player.gravity;
            player.velocity.y += gravity * Time.deltaTime;

            player.cc.Move((player.moveDir * player.moveSpeed + player.velocity) * Time.deltaTime);

            if (player.cc.isGrounded )
            {
                //Debug.Log("yv=" + player.velocity.y);
                player.velocity.y = -3;
                sm.ChangeState(player.standingState);

            }

        }
    }
}