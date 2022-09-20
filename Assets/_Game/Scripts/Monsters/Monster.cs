using _Game.Scripts.Food;
using UnityEngine;

namespace _Game.Scripts.Monsters
{
    public class Monster : MonoBehaviour
    {
        [SerializeField] private FoodTypes typeOfFoodHeEats;

        private int _health;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            MonsterEvents.OnMonsterFeed += EatFood;
        }

        private bool ValidateHealth()
        {
            if (_health > 0) return false;
            MonsterEvents.OnMonsterDie?.Invoke();
            return true;
        }

        private void EatFood(FoodBase foodBase)
        {
            if (foodBase.gameObject.CompareTag("Food"))
            {
                var type = foodBase.GetType();
                if (type == typeOfFoodHeEats)
                {
                    SimulateEatGoodFood(foodBase.GetPower());
                }
                else
                {
                    SimulateEatPoisonedFood(-foodBase.GetPower());
                }
            }
        }

        protected virtual void SimulateEatGoodFood(int power)
        {
            UpdateHealth(power);
            Debug.Log($"Eating fav food and my health is ");
            //maybe Play specific animation or sound or effect
        }
        
        protected virtual void SimulateEatPoisonedFood(int power)
        {
            UpdateHealth(power);
            Debug.Log($"Eating poisond food and my health is {_health}");
            //maybe Play specific animation or sound or effect
        }

        private void UpdateHealth(int value)
        {
            _health += value;
            if (ValidateHealth()) return;
            MonsterEvents.OnHealthChanged?.Invoke(_health);
        }

        private void OnDestroy()
        {
            MonsterEvents.OnMonsterFeed -= EatFood;
        }
    }
}