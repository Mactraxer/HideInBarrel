namespace Entities.Characters
{
    public interface IMainCharacterState
    {
        public void Enter(MainCharacterStateMachine contex);
        public void Exit();
        public void SetActiveMovement(bool active);
    }
}