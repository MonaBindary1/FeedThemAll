using System;

namespace _Game.Scripts.Monsters
{
    public static class MonsterEvents
    {
        public static Action<int> OnHealthChanged;
        public static Action OnMonsterDie;
        public static Action<Food.FoodBase> OnHitMonster;
    }
}