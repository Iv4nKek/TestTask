using Mirror;
using UnityEngine;

namespace Code.Model
{
    public class GatesMover : NetworkBehaviour
    {
        [SerializeField] private float _movementSpeed = 5;
        [SerializeField] private float _distance = 5;

        private float _initialPosition;
        private float _offset;
        private float _direction = 1;
        private void Start()
        {
            _initialPosition = transform.localPosition.z;
        }

        private void Update()
        {
            _offset += _direction * _movementSpeed * Time.deltaTime;
            if (_offset * _direction > _distance)
            {
                _direction *= -1;
            }
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, _initialPosition + _offset);
        }
    }
}