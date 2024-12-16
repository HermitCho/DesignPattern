namespace DesignPattern
{

    /*상태 패턴
    캐릭터 난이도 클래스 인터페이스
    */
    public interface ICharacterState
    {
        public void HandleAttack(BattleMediator mediator, int strength);
    }

    // 난이도 쉬움
    public class EasyMode : ICharacterState
    {
        public void HandleAttack(BattleMediator mediator, int strength)
        {
            Console.WriteLine("보스의 공격!");
            mediator.NotifyAttack(this, BossAttackType.SingleAttack, strength / 2);
        }
    }

    // 난이도 보통
    public class NormalMode : ICharacterState
    {
        public void HandleAttack(BattleMediator mediator, int strength)
        {
            Console.WriteLine("보스의 공격!");
            mediator.NotifyAttack(this, BossAttackType.AreaAttack, strength);
        }
    }

    //난이도 어려움
    public class HardMode : ICharacterState
    {
        public void HandleAttack(BattleMediator mediator, int strength)
        {
            Console.WriteLine("보스의 공격!");
            mediator.NotifyAttack(this, BossAttackType.SingleAttack, strength * 2);
            mediator.NotifyAttack(this, BossAttackType.AreaAttack, strength * 2);
        }
    }
}