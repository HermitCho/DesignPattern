
namespace characterState
{
    public interface ICharacterState
    {
        public void HandleAttack();
        public ICharacterState HandleReady();
        public ICharacterState HandleRest();
    }

    // 비전투 상태 클래스
    public class IdleState : ICharacterState
    {
        public void HandleAttack()
        {
            Console.WriteLine("비전투 상태에서는 공격할 수 없습니다.");
        }

        public ICharacterState HandleReady()
        {
            Console.WriteLine("캐릭터가 전투 준비 상태로 전환됩니다.");
            return new CombatState();
        }

        public ICharacterState HandleRest()
        {
            Console.WriteLine("캐릭터가 휴식을 취합니다.");
            return new RestState();
        }
    }

    // 전투 상태 클래스
    public class CombatState : ICharacterState
    {
        public void HandleAttack()
        {
            Console.WriteLine("캐릭터가 적을 공격합니다!");
        }

        public ICharacterState HandleReady()
        {
            Console.WriteLine("캐릭터가 비전투 준비 상태로 전환됩니다.");
            return new IdleState();
        }

        public ICharacterState HandleRest()
        {
            Console.WriteLine("전투 상태에서는 휴식할 수 없습니다.");
            return this;
        }
    }

    public class RestState : ICharacterState
    {
        public void HandleAttack()
        {
            Console.WriteLine("휴식 상태에서는 공격이 불가능합니다.");
        }

        public ICharacterState HandleReady()
        {
            Console.WriteLine("캐릭터가 비전투 준비 상태로 전환됩니다.");
            return new IdleState();
        }

        public ICharacterState HandleRest()
        {
            Console.WriteLine("캐릭터가 이미 휴식 중 입니다.");
            return this;
        }
    }
}