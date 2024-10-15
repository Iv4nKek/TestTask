using Mirror;
using UnityEngine;

namespace Code.Model
{
    public class Gates : NetworkBehaviour
    {
        [SerializeField] private PlayerScore _playerScore;
        private void OnCollisionEnter(Collision other)
        {
            if (isServer)
            {
                if (other.gameObject.GetComponent<Ball>() != null)
                {
                    _playerScore.Decrement();
                }
            }
        }
    }
}