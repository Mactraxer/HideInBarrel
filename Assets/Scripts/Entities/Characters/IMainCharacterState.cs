namespace Entities.Characters
{
    public interface IMainCharacterState
    {
        public void Enter();
        public void Exit();
        public void SetActiveMovement(bool active);
    }
}