namespace pa2_sdaudet_ua_1
{
    public class FireAttack : IAttack
    {
        public string ToTypeString(){
            return "Fire";
        }
        public void Attack(Character attacker, Character opponent){
            if (opponent.type=="Earth")
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