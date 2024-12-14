namespace DesignPattern
{
    public interface ICharacterState
    {
        public void HandleAttack(BattleMediator mediator, int strength);
    }

    // 비전투 상태 클래스
    public class EasyMode : ICharacterState
    {
        public void HandleAttack(BattleMediator mediator, int strength)
        {
            Console.WriteLine("광역 공격");
            mediator.Notify(this, "AreaAttack", strength);
        }
    }

    // 전투 상태 클래스
    public class NormalMode : ICharacterState
    {
        public void HandleAttack(BattleMediator mediator, int strength)
        {
            Console.WriteLine("2연속 광역 공격");
            mediator.Notify(this, "AreaAttack", strength);
            mediator.Notify(this, "AreaAttack", strength);
        }
    }

    public class HardMode : ICharacterState
    {
        public void HandleAttack(BattleMediator mediator, int strength)
        {
            Console.WriteLine("3연속 광역 공격");
            mediator.Notify(this, "AreaAttack", strength);
            mediator.Notify(this, "AreaAttack", strength);
            mediator.Notify(this, "AreaAttack", strength);
        }
    }
}