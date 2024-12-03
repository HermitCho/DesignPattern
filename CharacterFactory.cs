using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace DesignPattern
{
    // 캐릭터 팩토리
    public abstract class CharacterFactory()
    {
        //기본 값 베이스 인스턴스 생성 과정을 실행하는 함수
        public ICharacter CreateOperation()
        {
            ICharacter character = CreateCharacter();
            character.Display_Created();
            return character;
        }

        //커스텀 값 베이스 인스턴스 생성 과정을 실행하는 함수
        public virtual ICharacter CustomCreateOperation(string? name, int? level, int? strength, int? health)
        {
            ICharacter character = CustomCreateCharacter(name, level, strength, health);
            character.Display_Created();
            return character;
        }

        //기본 캐릭터 인스턴스를 실질적으로 만드는 함수
        public abstract ICharacter CreateCharacter();

        //커스텀 캐릭터 인스턴스를 실질적으로 만드는 함수
        public abstract ICharacter CustomCreateCharacter(string? name, int? level, int? strength, int? health);
    }

    public class PlayerFactory : CharacterFactory
    {
        // 플레이어 이름을 제외한 다른 값들은 기본 값을 기반으로 Player 인스턴스 생성
        public override ICharacter CreateCharacter()
        {
            Player player = new Player();
            player.SaveInfoToFile();
            player.increaseID();
            return player;
        }

        // 커스텀 생성 클래스는 플레이어 캐릭터에게 사용되지 않기 때문에 오류 구문을 통해 막아둠
        public override ICharacter CustomCreateOperation(string? name, int? level, int? strength, int? health)
        {
            throw new NotSupportedException("PlayerFactory에서는 CustomCreateOperation을 지원하지 않습니다.");
        }

        public override ICharacter CustomCreateCharacter(string? name, int? level, int? strength, int? health)
        {
            throw new NotSupportedException("PlayerFactory에서는 CustomCreateCharacter을 지원하지 않습니다.");
        }
    }

    public class GoblinFactory : CharacterFactory
    {
        // 기본 값을 사용하여 Goblin 인스턴스 생성
        public override ICharacter CreateCharacter()
        {
            string name = $"고블린 {Goblin.goblinNum}";
            int level = 1;
            int strength = 5;
            int health = 50;

            Goblin goblin = new Goblin(name, level, strength, health);
            return goblin;
        }

        // 커스텀 값을 사용하여 Goblin 인스턴스 생성
        public override ICharacter CustomCreateCharacter(string? name, int? level, int? strength, int? health)
        {
            name = name ?? $"고블린 {Goblin.goblinNum}";
            level = level ?? 1;
            strength = strength ?? 5;
            health = health ?? 50;

            Goblin goblin = new Goblin(name, level, strength, health);
            return goblin;
        }
    }

    public class SlimeFactory : CharacterFactory
    {
        // 기본 값을 사용하여 Slime 인스턴스 생성
        public override ICharacter CreateCharacter()
        {
            string name = $"슬라임 {Slime.slimeNum}";
            int level = 1;
            int strength = 3;
            int health = 30;

            Slime slime = new Slime(name, level, strength, health);
            return slime;
        }

        // 커스텀 값을 사용하여 Slime 인스턴스 생성
        public override ICharacter CustomCreateCharacter(string? name, int? level, int? strength, int? health)
        {
            name = name ?? $"슬라임 {Slime.slimeNum}";
            level = level ?? 1;
            strength = strength ?? 5;
            health = health ?? 50;

            Slime slime = new Slime(name, level, strength, health);
            return slime;
        }
    }
}