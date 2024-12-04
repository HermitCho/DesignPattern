namespace DesignPattern
{
    public interface ICharacterState
    {
        public void HandleAttack(IMediator mediator);
    }

    // 비전투 상태 클래스
    public class EasyMode : ICharacterState
    {
        public void HandleAttack(IMediator mediator)
        {
            Console.WriteLine("광역 공격");
            mediator.Notify(this, "AreaAttack");
        }
    }

    // 전투 상태 클래스
    public class NormalMode : ICharacterState
    {
        public void HandleAttack(IMediator mediator)
        {
            Console.WriteLine("2연속 광역 공격");
            mediator.Notify(this, "AreaAttack");
            mediator.Notify(this, "AreaAttack");
        }
    }

    public class HardMode : ICharacterState
    {
        public void HandleAttack(IMediator mediator)
        {
            Console.WriteLine("3연속 광역 공격");
            mediator.Notify(this, "AreaAttack");
            mediator.Notify(this, "AreaAttack");
            mediator.Notify(this, "AreaAttack");
        }
    }
}