using System;
using Mirror;

namespace Code.Model
{
    public class PlayerVisuals : NetworkBehaviour
    {
        [SyncVar(hook = nameof(OnColorIndexSet))]
        private byte _colorIndex;

        public event Action<byte> OnColorChanged;
        
        public byte VisualsIndex => _colorIndex;


        public override void OnStartClient()
        {
            if (isLocalPlayer)
            {
                SetColor(netIdentity.netId % 4);
            }
        }

        private void OnColorIndexSet(byte oldColor, byte newColor)
        {
            OnColorChanged?.Invoke(newColor);
        }

        public void SetColor(uint index)
        {
            _colorIndex = (byte)index;
            OnColorChanged?.Invoke(_colorIndex);
        }
    }
}