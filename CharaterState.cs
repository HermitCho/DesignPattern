//캐릭터 상태 인터페이스
public interface ICharacterState
{
    //캐릭터 상태 전환
    void ChangeIdleState(ICharacter character);
    void ChangeCombatState(ICharacter character);
}

//캐릭터의 비전투 상태 클래스
public class IdleState : ICharacterState
{
    public void ChangeIdleState(ICharacter character)
    {
        Console.WriteLine($"{character.GetType().Name}가 이미 비전투 상태입니다.");
    }
    public void ChangeCombatState(ICharacter character)
    {
        character.SetState(new CombatState());
        Console.WriteLine($"{character.GetType().Name}가 전투 상태가 되었습니다.");
    }
}

//캐릭터의 전투 상태 클래스
public class CombatState : ICharacterState
{
    public void ChangeIdleState(ICharacter character)
    {
        character.SetState(new IdleState());
        Console.WriteLine($"{character.GetType().Name}가 비전투 상태가 되었습니다.");
    }
    public void ChangeCombatState(ICharacter character)
    {
        Console.WriteLine($"{character.GetType().Name}가 이미 전투 상태입니다.");
    }
}