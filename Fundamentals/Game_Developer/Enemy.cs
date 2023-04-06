class Enemy
{
    public string Name;
    public int Health;
    public List<Attack> AttackList;
    public Enemy(string name, List<Attack> attackList, int health = 100)
    {
        Name = name;
        Health = health;
        AttackList = attackList;
    }

    public void RandomAttack()
    {
        Random rand = new Random();
        int attacknum = rand.Next(0, AttackList.Count);
        Attack attack = AttackList[attacknum];
        Console.WriteLine($"{Name} attacks with {attack.Name}!");
    }

    public virtual void AddAttack(Attack newAttack)
    {
        AttackList.Add(newAttack);
    }

    public virtual void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        if (Target.Health <= 0)
        {
            Console.WriteLine($"{Name} tried to attack {Target.Name} but they are already passed out!");
        }
        else if (Health <= 0)
        {
            Console.WriteLine($"{Name} has no energy left to attack!");
        }
        else
        {
            Target.Health = Target.Health - ChosenAttack.DamageAmount;
            Console.WriteLine($"{Name} attacks {Target.Name}, dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target.Health}");
        }
    }
}





