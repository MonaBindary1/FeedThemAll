using _Game.Scripts.Behaviour.Food;
using UnityEngine;

namespace _Game.Scripts.Behaviour.ClickBehaviour
{
    public abstract class Clickable : MonoBehaviour,IClickable
    {
        [SerializeField] private FoodTypes type;
        private void OnMouseDown()
        {
           ActOnClick();
        }
        
        public virtual void ActOnClick()
        {
           
        }

        protected void MoveToTarget(Vector3 targetPosition, float time)
        {
            //Dotween move
        }

        public FoodTypes GetType()
        {
            return type;
        }
    }
}
