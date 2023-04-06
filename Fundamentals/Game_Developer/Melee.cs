class Melee : Enemy
{
    // ! Add attacks to attack list?

    public Melee(string name, List<Attack> attacklist) : base(name, attacklist, 120)
    {

    }

    public override void AddAttack(Attack newAttack)
    {
        base.AddAttack(newAttack);
    }

    public override void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        base.PerformAttack(Target, ChosenAttack);
    }

    // ! Making this attack a random attack inside the method?
    public void RageAttack(Enemy Target)
    {
        Random rand = new Random();
        int attacknum = rand.Next(0, AttackList.Count);
        Attack rage_attack = AttackList[attacknum];
        Target.Health = Target.Health - rage_attack.DamageAmount - 10;
        Console.WriteLine($"{Name} rage attacks {Target.Name}, dealing {rage_attack.DamageAmount + 10} damage and reducing {Target.Name}'s health to {Target.Health}");
    }
}