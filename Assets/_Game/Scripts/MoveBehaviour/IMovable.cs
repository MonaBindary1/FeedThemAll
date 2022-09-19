using System;
using UnityEngine;

namespace _Game.Scripts.MoveBehaviour
{
    public interface  IMovable
    {
        void MoveToTarget(Vector3 target, float time, Action callback);
    }
}