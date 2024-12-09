namespace DesignPattern
{
    public interface IMediator
    {
        void Notify(object sender, string eventCode);
    }
    public class BattleMediator : IMediator
    {
        private Boss _boss;
        private List<Player> _players = new List<Player>();
        private List<Monster> _monsters = new List<Monster>();

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

        public void Notify(object sender, string eventCode)
        {
            if (eventCode == "AreaAttack")
            {
                foreach (var player in _players)
                {
                    player.TakeDamage(_boss.GetAreaDamage());
                }
                foreach (var monster in _monsters)
                {
                    monster.TakeDamage(_boss.GetAreaDamage());
                }
            }
        }
    }
}


