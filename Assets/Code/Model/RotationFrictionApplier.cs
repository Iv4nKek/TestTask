using UnityEngine;

namespace Code.Model
{
    public class RotationFrictionApplier : MonoBehaviour
    {
        [SerializeField] private Rigidbody _target;
        [SerializeField] private float _angularFrictionOnCollision;
        [SerializeField] private PhysicMaterial _targetMaterial;

        private float _initialAngularDrag;

        private void Start()
        {
            _initialAngularDrag = _target.angularDrag;
        }

        private void ApplyRotationFriction()
        {
            _target.angularDrag = _angularFrictionOnCollision;
        }
        
        private void CancelRotationFriction()
        {
            _target.angularDrag = _initialAngularDrag;
        }

        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.TryGetComponent<Collider>(out var collider))
            {
                if (collider.sharedMaterial == _targetMaterial)
                {
                    ApplyRotationFriction();
                }
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if(other.gameObject.TryGetComponent<Collider>(out var collider))
            {
                if (collider.sharedMaterial == _targetMaterial)
                {
                    CancelRotationFriction();
                }
            }
        }
    }
}