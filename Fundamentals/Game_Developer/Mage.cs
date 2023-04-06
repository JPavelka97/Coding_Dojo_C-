class Mage : Enemy
{

    public Mage(string name, List<Attack> attacklist) : base(name, attacklist, 80)
    {

    }

    public void Heal(Enemy Target)
    {
        Target.Health = Target.Health + 40;
        Console.WriteLine($"{Name} has healed {Target.Name} for 40 health, resulting in a new health of {Target.Health}");
    }
}