using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Model
{
    public class GunRotator : MonoBehaviour
    {
        [SerializeField] private NetworkIdentity _identity;
        [SerializeField] private InputActionReference _lookAction;
        [SerializeField] private float _rotationSpeed = 5f;
        [SerializeField] private float _rotationAngleLimit = 60f;

        private void Start()
        {
            if (!_identity.isLocalPlayer)
            {
                Destroy(this);
            }
        }

        private void Update()
        {
            if (_lookAction.action.WasPerformedThisFrame())
            {
                Vector2 delta = _lookAction.action.ReadValue<Vector2>();
                if (delta != Vector2.zero)
                {
                    Rotate(delta);
                }
            }
        }
        
        private void Rotate(Vector2 obj)
        {
            float newAngle = transform.localEulerAngles.y + obj.x * _rotationSpeed * Time.deltaTime;
            if (Mathf.Abs(newAngle) < _rotationAngleLimit || Mathf.Abs(newAngle)> 360- _rotationAngleLimit)
            {
                transform.localEulerAngles = new Vector3(transform.eulerAngles.x, newAngle, transform.eulerAngles.z);
            }
        }
    }
}