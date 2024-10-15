using Mirror;

namespace Code.Util
{
    public class DestroyIfNotLocal : NetworkBehaviour
    {
        public override void OnStartClient()
        {
            if (!isLocalPlayer)
            {
                Destroy(gameObject);
            }
        }
    }
}