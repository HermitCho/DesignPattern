using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace DesignPattern
{
    // 캐릭터 팩토리
    public abstract class CharacterFactory<T>() where T : ICharacter
    {
        //기본 값 베이스 인스턴스 생성 과정을 실행하는 함수
        public T CreateOperation()
        {
            T character = CreateCharacter();
            character.Display_Created();
            return character;
        }

        //커스텀 값 베이스 인스턴스 생성 과정을 실행하는 함수
        public virtual T CustomCreateOperation(string? name, int? level, int? strength, int? health)
        {
            T character = CustomCreateCharacter(name, level, strength, health);
            character.Display_Created();
            return character;
        }

        //기본 캐릭터 인스턴스를 실질적으로 만드는 함수
        public abstract T CreateCharacter();

        //커스텀 캐릭터 인스턴스를 실질적으로 만드는 함수
        public abstract T CustomCreateCharacter(string? name, int? level, int? strength, int? health);
    }

    public class PlayerFactory : CharacterFactory<Player>
    {
        // 플레이어 이름을 제외한 다른 값들은 기본 값을 기반으로 Player 인스턴스 생성
        public override Player CreateCharacter()
        {
            Player player = new Player();
            player.SaveInfoToFile();
            player.increaseID();
            return player;
        }

        // 커스텀 생성 클래스는 플레이어 캐릭터에게 사용되지 않기 때문에 오류 구문을 통해 막아둠
        public override Player CustomCreateOperation(string? name, int? level, int? strength, int? health)
        {
            throw new NotSupportedException("PlayerFactory에서는 CustomCreateOperation을 지원하지 않습니다.");
        }

        public override Player CustomCreateCharacter(string? name, int? level, int? strength, int? health)
        {
            throw new NotSupportedException("PlayerFactory에서는 CustomCreateCharacter을 지원하지 않습니다.");
        }
    }

    public class GoblinFactory : CharacterFactory<Goblin>
    {
        // 기본 값을 사용하여 Goblin 인스턴스 생성
        public override Goblin CreateCharacter()
        {
            string name = $"고블린 {Goblin.goblinNum}";
            int level = 1;
            int strength = 5;
            int health = 50;

            Goblin goblin = new Goblin(name, level, strength, health);
            return goblin;
        }

        // 커스텀 값을 사용하여 Goblin 인스턴스 생성
        public override Goblin CustomCreateCharacter(string? name, int? level, int? strength, int? health)
        {
            name = name ?? $"고블린 {Goblin.goblinNum}";
            level = level ?? 1;
            strength = strength ?? 5;
            health = health ?? 50;

            Goblin goblin = new Goblin(name, level, strength, health);
            return goblin;
        }
    }

    public class DragonFactory : CharacterFactory<Dragon>
    {
        // 기본 값을 사용하여 Dragon 인스턴스 생성
        public override Dragon CreateCharacter()
        {
            string name = $"드래곤 {Dragon.dragonNum}";
            int level = 30;
            int strength = 100;
            int health = 3000;

            Dragon dragon = new Dragon(name, level, strength, health);
            return dragon;
        }

        // 커스텀 값을 사용하여 Dragon 인스턴스 생성
        public override Dragon CustomCreateCharacter(string? name, int? level, int? strength, int? health)
        {
            name = $"드래곤 {Dragon.dragonNum}";
            level = level ?? 30;
            strength = strength ?? 100;
            health = health ?? 3000;

            Dragon dragon = new Dragon(name, level, strength, health);
            return dragon;
        }
    }
}