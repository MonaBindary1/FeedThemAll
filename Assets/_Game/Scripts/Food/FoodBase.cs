using System;
using _Game.Scripts.Behaviour.ClickBehaviour;
using _Game.Scripts.Monsters;
using _Game.Scripts.MoveBehaviour;
using DG.Tweening;
using UnityEngine;

namespace _Game.Scripts.Food
{
    public class FoodBase : MonoBehaviour,IClickable, IMovable
    {
        [SerializeField] private FoodTypes type;

        private Sequence _sequence;

        private Transform _target;
        private float _movingTime ;
        private void Start()
        {
            Init();
            MoveToTarget(_target.position, _movingTime,OnReachDestination);
        }

        private void Init()
        {
            _sequence = DOTween.Sequence();
            _target = GameElementHolder.Instance.GetFoodTarget();
            _movingTime = 5.8f;
        }

        private void OnMouseDown()
        {
            ActOnClick();
        }

        public void ActOnClick()
        {
            //Get Monster and move to it
            _target = GameElementHolder.Instance.GetMonster().transform;
            MoveToTarget(_target.position, _movingTime, FeedMonster);
        }

        public void MoveToTarget(Vector3 target, float time, Action callback)
        {
            if (_sequence != null)
            {
                _sequence.Kill();
            }

            _sequence.Append(transform.DOMove(target, time).OnComplete(() =>
            {
                callback();
            }).SetEase(Ease.Linear));
            _sequence.Play();
        }

        private void OnReachDestination()
        {
            Destroy(gameObject);
        }
        
        private void FeedMonster()
        {
          MonsterEvents.OnHitMonster?.Invoke(this);
          OnReachDestination();
        }
        

        public FoodTypes GetType()
        {
            return type;
        }
    }
}