using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Food
{
    public class FoodFactory : MonoBehaviour
    {
        [SerializeField] private List<Food> foodToGenerate;
        [SerializeField] private float timeToInitFood;
        [SerializeField] private Transform foodParent;

        private void Start()
        {
            StartCoroutine(GenerateFood());
        }

        IEnumerator GenerateFood()
        {
            while (true)
            {
                Instantiate(GetRandomFoodToSpawn(), foodParent);
                yield return new WaitForSeconds(timeToInitFood);
            }
        }

        private Food GetRandomFoodToSpawn()
        {
            var index = Random.Range(0, foodToGenerate.Count);
            return foodToGenerate[index];
        }
    }
}