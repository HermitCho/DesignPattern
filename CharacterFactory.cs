using System;
using System.IO;

//캐릭터 인터페이스
public interface ICharacter
{
    void Display();
    ICharacterState CurrentState { get; set; }
    public string name { get; set; }
    public int level { get; set; }
    public int strength { get; set; }
    public int health { get; set; }
    public void SetState(ICharacterState newState);
    public void IdleState();
    public void CombatState();
    string GetInfo();
    public void increaseCharacter();
}

//플레이어 클래스
public class Player : ICharacter
{
    public static int playerNum = 1;
    public ICharacterState CurrentState { get; set; } = new IdleState();
    public string name { get; set; }
    public int level { get; set; }
    public int strength { get; set; }
    public int health { get; set; }

    //콘솔 창에 플레이어 캐릭터 생성 표시
    public void Display()
    {
        Console.WriteLine("플레이어 " + playerNum + " 가 생성되었습니다.");
    }

    //
    public void SetState(ICharacterState newState)
    {
        CurrentState = newState;
    }
    public void IdleState()
    {
        CurrentState.ChangeIdleState(this);
    }
    public void CombatState()
    {
        CurrentState.ChangeCombatState(this);
    }

    public string GetInfo()
    {
        return $"이름: {name}\n레벨 : {level}\n공격력 : {strength}\n체력 : {health}\n현재 상태 : {CurrentState.GetType().Name}\r\n";
    }

    public void SaveInfoToFile(string filePath)
    {
        try
        {
            File.WriteAllText(filePath, GetInfo());
            Console.WriteLine($"{filePath}에 정보 저장");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"파일 저장 오류 : {ex.Message}");
        }
    }
    public void increaseCharacter()
    {
        playerNum++;
    }
}

//몬스터 클래스 추상
public abstract class Monster : ICharacter
{
    public abstract ICharacterState CurrentState { get; set; }
    public abstract string name { get; set; }
    public abstract int level { get; set; }
    public abstract int strength { get; set; }
    public abstract int health { get; set; }

    public abstract void Display();

    public abstract void SetState(ICharacterState newState);

    public abstract void IdleState();
    public abstract void CombatState();
    public abstract string GetInfo();
    public abstract void increaseCharacter();
}

//몬스터 클래스를 상속받은 고블린 클래스
public class Goblin : Monster
{
    public static int goblinNum = 1;
    public override ICharacterState CurrentState { get; set; } = new IdleState();
    public override string name { get; set; }
    public override int level { get; set; }
    public override int strength { get; set; }
    public override int health { get; set; }

    public override void Display()
    {
        Console.WriteLine("고블린 " + goblinNum + " 이 나타났습니다.");
    }
    public override void SetState(ICharacterState newState)
    {
        CurrentState = newState;
    }
    public override void IdleState()
    {
        CurrentState.ChangeIdleState(this);
    }
    public override void CombatState()
    {
        CurrentState.ChangeCombatState(this);
    }

    public override string GetInfo()
    {
        return $"이름: {name}\n레벨 : {level}\n공격력 : {strength}\n체력 : {health}\n현재 상태 : {CurrentState.GetType().Name}\r\n";
    }
    public override void increaseCharacter()
    {
        goblinNum++;
    }
}

public class Slime : Monster
{
    public static int slimeNum = 1;
    public override ICharacterState CurrentState { get; set; } = new IdleState();
    public override string name { get; set; }
    public override int level { get; set; }
    public override int strength { get; set; }
    public override int health { get; set; }

    public override void Display()
    {
        Console.WriteLine("슬라임 " + slimeNum + " 이 나타났습니다.");
    }
    public override void SetState(ICharacterState newState)
    {
        CurrentState = newState;
    }
    public override void IdleState()
    {
        CurrentState.ChangeIdleState(this);
    }
    public override void CombatState()
    {
        CurrentState.ChangeCombatState(this);
    }

    public override string GetInfo()
    {
        return $"이름: {name}\n레벨 : {level}\n공격력 : {strength}\n체력 : {health}\n현재 상태 : {CurrentState.GetType().Name}\r\n";
    }
    public override void increaseCharacter()
    {
        slimeNum++;
    }
}

//캐릭터 팩토리
public static class CharacterFactory
{

    public static ICharacter CreateCharacter(string type, string? name = null, int? level = null, int? strength = null, int? health = null)
    {
        return type switch
        {
            "Player" => CreatePlayer(name, level, strength, health),
            "Goblin" => CreateGoblin(name, level, strength, health),
            "Slime" => CreateSlime(name, level, strength, health),
            _ => throw new ArgumentException("허용된 캐릭터 타입이 아닙니다.")
        };
    }

    // 플레이어 객체 생성 및 초기화
    private static Player CreatePlayer(string? name, int? level, int? strength, int? health)
    {
        string playerName = name ?? $"플레이어 {Player.playerNum}";

        var player = new Player
        {
            name = playerName,
            level = level ?? 1,
            strength = strength ?? 10,
            health = health ?? 100
        };

        player.Display();
        if (name == null)
        {
            player.increaseCharacter();
        }
        return player;
    }

    // 고블린 객체 생성 및 초기화
    private static Goblin CreateGoblin(string? name, int? level, int? strength, int? health)
    {
        string goblinName = name ?? $"고블린 {Goblin.goblinNum}";

        var goblin = new Goblin
        {
            name = goblinName,
            level = level ?? 1,
            strength = strength ?? 5,
            health = health ?? 20
        };

        goblin.Display();
        if (name == null)
        {
            goblin.increaseCharacter();
        }
        return goblin;
    }

    //슬라임 객체 생성 및 초기화
    private static Slime CreateSlime(string? name, int? level, int? strength, int? health)
    {
        string slimeName = name ?? $"슬라임 {Slime.slimeNum}";

        var slime = new Slime
        {
            name = slimeName,
            level = level ?? 1,
            strength = strength ?? 3,
            health = health ?? 10
        };

        slime.Display();
        if (name == null)
        {
            slime.increaseCharacter();
        }
        return slime;
    }
}