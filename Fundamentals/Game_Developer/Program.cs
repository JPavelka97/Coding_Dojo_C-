Attack Arrow = new Attack("Shoot an Arrow", 20);
Attack Knife = new Attack("Throw a Knife", 15);

Attack Punch = new Attack("Punch", 20);
Attack Kick = new Attack("Kick", 15);
Attack Tackle = new Attack("Tackle", 25);

Attack Fireball = new Attack("Fireball", 25);
Attack Lightning = new Attack("Lightning Bolt", 20);
Attack Staff = new Attack("Staff Strike", 10);

List<Attack> MeleeAttacks = new List<Attack>() {Punch, Kick, Tackle};
List<Attack> RangedAttacks = new List<Attack>() {Arrow, Knife};
List<Attack> MageAttacks = new List<Attack>() {Fireball, Lightning, Staff};

Melee MeleeRay = new Melee("Melee Ray", MeleeAttacks);
Ranged RangedJane = new Ranged("Ranged Jane", RangedAttacks);
Mage MageNickCage = new Mage("Mage Nick Cage", MageAttacks);

MeleeRay.PerformAttack(RangedJane, Kick);
MeleeRay.RageAttack(MageNickCage);
RangedJane.PerformAttack(MeleeRay, Arrow);
RangedJane.Dash();
RangedJane.PerformAttack(MeleeRay, Arrow);
MageNickCage.PerformAttack(MeleeRay, Fireball);
MageNickCage.Heal(RangedJane);
MageNickCage.Heal(MageNickCage);