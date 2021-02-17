namespace pa2_sdaudet_ua_1
{
    public class AirAttack : IAttack
    {
        public void Attack(Character attacker, Character opponent){
            if (opponent.type=="Fire")
            {
                opponent.health = opponent.health - ((attacker.attackPower/opponent.defensePower) * 1.2);
            }
            else
            {
                opponent.health = opponent.health - (attacker.attackPower/opponent.defensePower);
            }
        }
    }
}