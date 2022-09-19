using _Game.Scripts.Monsters;
using UnityEngine;

namespace _Game.Scripts
{
    public class GameElementHolder : MonoBehaviour
    {
        public static GameElementHolder Instance;
        
        [SerializeField] Transform foodTarget;
        [SerializeField] Monster monster;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public  Monster GetMonster()
        {
            return monster;
        }

        public Transform GetFoodTarget()
        {
            return foodTarget;
        }
    }
}