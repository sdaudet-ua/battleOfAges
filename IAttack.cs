namespace pa2_sdaudet_ua_1
{
    public interface IAttack
    {
        public string ToTypeString();//Used by Character to keep track of the attackMethod in a string format. 
        public void Attack(Character attacker,Character opponent);//Interface method for use in concrete implementations. 
    }
}