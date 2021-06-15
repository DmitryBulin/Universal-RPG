using UnityEngine;

namespace UniversalRPG.Characters
{
    public abstract class Character : ScriptableObject
    {
        [SerializeField] private Animator characterAnimator;
        public Animator CharacterAnimator { get => characterAnimator; }
    }
}
