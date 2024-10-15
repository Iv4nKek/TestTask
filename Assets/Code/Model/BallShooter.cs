using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Model
{
    public class BallShooter : NetworkBehaviour
    {
        [SerializeField] private float _forceTime;
        [SerializeField] private float _maxForce;
        [SerializeField] private float _minForce;

        [SerializeField] private GameObject _ballPrefab;
        [SerializeField] private Transform _ballStartPoint;
        [SerializeField] private PlayerScore _playerScore;

        [SerializeField] private InputActionReference _shootAction;

        private bool _isHolding;
        private float _holdTime;
        
        private void Start()
        {
            if (isLocalPlayer)
            {
                _shootAction.action.performed += OnFirePress;
                _shootAction.action.canceled += OnHoldEnded;
            }
        
        }
        
        private void OnDestroy()
        {
            if (isLocalPlayer)
            {
                _shootAction.action.performed -= OnFirePress;
                _shootAction.action.canceled -= OnHoldEnded;
            }
        }
        
        private void OnFirePress(InputAction.CallbackContext obj)
        {
            _isHolding = true;
        }

        private void OnHoldEnded(InputAction.CallbackContext obj)
        {
            float force = Mathf.Lerp(_minForce, _maxForce,  Mathf.Clamp(_holdTime, 0f, _forceTime));
            ShootBall(force);
            _holdTime = 0;
            _isHolding = false;
        }

        private void Update()
        {
            if (_isHolding)
            {
                _holdTime += Time.deltaTime;
            }
        }
        
        //We can use a pool here, but balls don't spawn so fast to make it performance issue.
        [Command]
        private void ShootBall(float force)
        {
            GameObject ball = Instantiate(_ballPrefab, _ballStartPoint.position,  transform.rotation);
            ball.GetComponent<Ball>().SetPlayerScore(_playerScore);
            ball.GetComponent<Ball>().InitForce( _ballStartPoint.right * force);
            NetworkServer.Spawn(ball);
        }
    }
}