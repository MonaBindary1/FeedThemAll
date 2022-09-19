using _Game.Scripts.Behaviour.ClickBehaviour;
using _Game.Scripts.MoveBehaviour;
using UnityEngine;

namespace _Game.Scripts.Food
{
    public class Food : MonoBehaviour,IClickable, IMovable
    {
        [SerializeField] private FoodTypes type;
        [SerializeField] private Transform target;
        
        private void OnMouseDown()
        {
            ActOnClick();
        }

        public void ActOnClick()
        {
            //Get Monster and move to it
            //MoveToTarget();
        }

        public void MoveToTarget(Vector3 target, float time)
        {
        }
        
        public FoodTypes GetType()
        {
            return type;
        }
    }
}