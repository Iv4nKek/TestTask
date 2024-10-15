using System;
using Mirror;

namespace Code.Model
{
    public class PlayerScore : NetworkBehaviour
    {
        [SyncVar(hook = nameof(OnScoreSet))] 
        public int _score;

        public event Action<int> OnScoreChanged;

        private void OnScoreSet(int oldScore, int NewScore)
        {
            OnScoreChanged?.Invoke(NewScore);
        }
        
        [Server]
        public void Increment()
        {
            _score++;
        }
        
        [Server]
        public void Decrement()
        {
            _score--;
        }
    }
}