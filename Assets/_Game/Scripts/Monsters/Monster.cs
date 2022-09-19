using _Game.Scripts.Food;
using UnityEngine;

namespace _Game.Scripts.Monsters
{
    public abstract class Monster : MonoBehaviour
    {

        [SerializeField] private FoodTypes typeOfFoodHeEats;

        private int _health
        {
            get => _health;
            set
            {
                MonsterEvents.OnHealthChanged?.Invoke(_health);
                Debug.Log("Health Changed");
            }
        }

        public virtual void SimulateEatRightFood()
        {
            _health++;
            //maybe Play specific animation or sound or effect
        }
        
        public virtual void SimulateEatWrongFood()
        {
            _health--;
            //maybe Play specific animation or sound or effect
        }
    }
}