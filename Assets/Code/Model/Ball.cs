using Mirror;
using UnityEngine;

namespace Code.Model
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : NetworkBehaviour
    {
        [SerializeField] private float _destroyAfter;
        private PlayerScore _playerScore;
        
        [SyncVar] private Vector3 _forceToApply;
        
        private void Start()
        {
            GetComponent<Rigidbody>().AddForce(_forceToApply);
        }

        public override void OnStartServer()
        {
            Invoke(nameof(DestroySelf), _destroyAfter);
        }

        public void InitForce(Vector3 force)
        {
            _forceToApply = force;
        }
        
        [Server]
        void DestroySelf()
        {
            NetworkServer.Destroy(gameObject);
        }

        public void SetPlayerScore(PlayerScore playerScore)
        {
            _playerScore = playerScore;
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (isServer)
            {
                if (other.gameObject.GetComponent<Gates>() != null)
                {
                    _playerScore.Increment();
                    DestroySelf();
                }
            }
            
        }
    }
}