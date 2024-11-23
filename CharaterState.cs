//캐릭터 상태 인터페이스
public interface ICharacterState
{
    //캐릭터 상태 전환
    void Handle(ICharacter character);
}

//캐릭터의 비전투 상태 클래스
public class IdleState : ICharacterState
{
    public void Handle(ICharacter character)
    {
        Console.WriteLine($"{character.GetType().Name}가 비전투 상태입니다.");
    }
}

//캐릭터의 전투 상태 클래스
public class CombatState : ICharacterState
{
    public void Handle(ICharacter character)
    {
        Console.WriteLine($"{character.GetType().Name}가 전투 상태입니다.");
    }
}