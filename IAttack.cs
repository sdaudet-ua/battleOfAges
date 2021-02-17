namespace pa2_sdaudet_ua_1
{
    public interface IAttack
    {
        public string ToTypeString();
        public void Attack(Character attacker,Character opponent);
    }
}