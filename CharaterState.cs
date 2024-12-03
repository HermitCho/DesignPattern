namespace DesignPattern
{
    public interface ICharacterState
    {
        public void HandleAttack();
        public void HandleDefense();
        public void HandleStun();
    }

    // 비전투 상태 클래스
    public class EasyMode : ICharacterState
    {
        public void HandleAttack()
        {
            Console.WriteLine("부채꼴 공격");
        }

        public void HandleDefense()
        {
            Console.WriteLine("캐릭터가 전투 준비 상태로 전환됩니다.");
        }

        public void HandleStun()
        {
            Console.WriteLine("캐릭터가 휴식을 취합니다.");
        }
        //handleEvent()
        // {
        //     Console.WriteLine("비전투 상태에서는 공격할 수 없습니다.");
        // }
    }

    // 전투 상태 클래스
    public class NormalMode : ICharacterState
    {
        public void HandleAttack()
        {
            Console.WriteLine("캐릭터가 공격합니다!");
        }

        public void HandleDefense()
        {
            Console.WriteLine("캐릭터가 비전투 준비 상태로 전환됩니다.");
        }

        public void HandleStun()
        {
            Console.WriteLine("전투 상태에서는 휴식할 수 없습니다.");
        }
    }

    public class HardMode : ICharacterState
    {
        public void HandleAttack()
        {
            Console.WriteLine("휴식 상태에서는 공격이 불가능합니다.");
        }

        public void HandleDefense()
        {
            Console.WriteLine("캐릭터가 비전투 준비 상태로 전환됩니다.");
        }

        public void HandleStun()
        {
            Console.WriteLine("캐릭터가 이미 휴식 중 입니다.");
        }
    }
}