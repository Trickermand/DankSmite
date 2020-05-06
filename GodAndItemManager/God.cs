using System;

//gaiController
namespace GodAndItemManager
{
    public enum AttackType
    {
        Melee,
        Ranged
    }

    public enum PowerType
    {
        Magical,
        Physical
    }

    public enum GodClass
    {
        Assassin,
        Guardian,
        Hunter,
        Mage,
        Warrior
    }

    public class God
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Pantheon { get; set; }
        public AttackType AttackType { get; private set; }
        public PowerType PowerType { get; private set; }
        public GodClass GodClass { get; private set; }
        public string Difficulty { get; set; }
        public string FavorCost { get; set; }
        public string GemsCost { get; set; }
        public string ReleaseDate { get; set; }

        public God()
        {

        }

        public void SetAttackType(string attackType)
        {
            switch (attackType.ToLower())
            {
                case "melee":
                    AttackType = AttackType.Melee;
                    break;
                case "ranged":
                    AttackType = AttackType.Ranged;
                    break;
                default:
                    throw new Exception($"Could not set {nameof(AttackType)}, was {attackType}.");
            }
        }

        public void SetPowerType(string powerType)
        {
            switch (powerType.ToLower())
            {
                case "magical":
                    PowerType = PowerType.Magical;
                    break;
                case "physical":
                    PowerType = PowerType.Physical;
                    break;
                default:
                    throw new Exception($"Could not set {nameof(PowerType)}, was {powerType}.");
            }
        }

        public void SetGodClass(string godClass)
        {
            switch (godClass.ToLower())
            {
                case "assassin":
                    GodClass = GodClass.Assassin;
                    break;
                case "guardian":
                    GodClass = GodClass.Guardian;
                    break;
                case "hunter":
                    GodClass = GodClass.Hunter;
                    break;
                case "mage":
                    GodClass = GodClass.Mage;
                    break;
                case "warrior":
                    GodClass = GodClass.Warrior;
                    break;
                default:
                    throw new Exception($"Could not set {nameof(GodClass)}, was {godClass}.");
            }
        }






    }
}
