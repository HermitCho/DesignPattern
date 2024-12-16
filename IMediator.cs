namespace DesignPattern
{

    public enum BossAttackType
    {
        SingleAttack,
        AreaAttack
    }

    //중재자로 전투 중인 객체들 연결
    public interface IMediator
    {
        void NotifyAttack(object sender, BossAttackType type, int strength);
    }


    //전투 중재자
    public class BattleMediator : IMediator
    {
        private Boss? _boss; //공격자
        private List<Player> _players = new List<Player>(); //피격 플레이어
        private List<Monster> _monsters = new List<Monster>(); //피격 몬스터


        public void RegisterBoss(Boss boss)
        {
            _boss = boss;
        }

        public void RegisterPlayer(Player player)
        {
            _players.Add(player);
        }

        public void RegisterMonster(Monster monster)
        {
            _monsters.Add(monster);
        }

        public void UnregisterBoss()
        {
            _boss = null;
        }

        public void UnregisterPlayer(Player player)
        {
            _players.Remove(player);
        }

        public void UnregisterMonster(Monster monster)
        {
            _monsters.Remove(monster);
        }

        public void NotifyAttack(object sender, BossAttackType type, int strength)
        {
            //광역 공격 시
            if (type == BossAttackType.AreaAttack)
            {
                foreach (var player in _players)
                {
                    player.TakeDamage(strength);
                }
                foreach (var monster in _monsters)
                {
                    monster.TakeDamage(strength);
                }
            }

            //단일 공격 시
            else if (type == BossAttackType.SingleAttack)
            {
                _players[0].TakeDamage(strength);
            }
        }
    }
}


