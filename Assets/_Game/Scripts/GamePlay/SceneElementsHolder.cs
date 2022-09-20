using _Game.Scripts.Monsters;
using UnityEngine;

namespace _Game.Scripts
{
    public class SceneElementsHolder : MonoBehaviour
    {
        public static SceneElementsHolder Instance;
        
        [SerializeField] private Transform foodTarget;
        [SerializeField] private Monster monster;

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