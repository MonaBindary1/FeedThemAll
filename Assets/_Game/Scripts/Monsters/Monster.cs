using System;
using _Game.Scripts.Food;
using UnityEngine;

namespace _Game.Scripts.Monsters
{
    public class Monster : MonoBehaviour
    {
        [SerializeField] private FoodTypes typeOfFoodHeEats;

        private int _health
        {
            get => _health;
            set
            {
                if (ValidateHealth()) return;
                MonsterEvents.OnHealthChanged?.Invoke(_health);
            }
        }

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            MonsterEvents.OnHitMonster += EatFood;
        }

        private bool ValidateHealth()
        {
            if (_health <= 0)
            {
                MonsterEvents.OnMonsterDie?.Invoke();
                return true;
            }

            return false;
        }

        private void EatFood(FoodBase foodBase)
        {
            if (foodBase.gameObject.CompareTag("Food"))
            {
                var type = foodBase.GetType();
                if (type == typeOfFoodHeEats)
                {
                    SimulateEatGoodFood();
                }
                else
                {
                    SimulateEatPoisonedFood();
                }
            }
        }

        protected virtual void SimulateEatGoodFood()
        {
            _health++;
            Debug.Log($"Eating fav food and my health is {_health}");
            //maybe Play specific animation or sound or effect
        }
        
        protected virtual void SimulateEatPoisonedFood()
        {
            _health--;
            Debug.Log($"Eating poisond food and my health is {_health}");
            //maybe Play specific animation or sound or effect
        }

        private void OnDestroy()
        {
            MonsterEvents.OnHitMonster -= EatFood;
        }
    }
}