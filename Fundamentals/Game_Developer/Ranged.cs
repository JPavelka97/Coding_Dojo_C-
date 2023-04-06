class Ranged : Enemy
{
    public int Distance;
    public Ranged(string name, List<Attack> attacklist, int distance = 5) : base(name, attacklist)
    {
        Distance = distance;
    }

    public override void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        if (Distance < 10)
        {
            Console.WriteLine($"{Name} is too close to {Target.Name} to attack!");
        }
        else
        {
            base.PerformAttack(Target, ChosenAttack);
        }
    }

    public void Dash()
    {
        Distance = 20;
    }
}