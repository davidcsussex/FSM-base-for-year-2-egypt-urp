
using UnityEngine;
using UnityEngine.AI;
namespace Player
{
    public class EnterCarState : State
    {

        float timeToGetInCar;
        bool doEnterCar, doWalkToCar;
        

        // constructor
        public EnterCarState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            timeToGetInCar = 2;
            doEnterCar = false;
            doWalkToCar = false;
            player.reEnterVehicleTimer = 10;

            base.Enter();
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

        }


        //call this when player is inside vehicle
/*
        vehicle = hit.collider.gameObject;
                vehicle.GetComponent<MoveSteerVehicle>().drivable = true;
                cc.enabled = false;
*/


        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}