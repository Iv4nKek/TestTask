using Code.Model;
using UnityEngine;

namespace Code.View
{
    public class PlayerVisualsApplier : MonoBehaviour
    {
        [SerializeField] private PlayerVisuals _playerVisuals;
        [SerializeField] private Renderer _target;
        [SerializeField] private MaterialTable _materialTable;
        
        private void Start()
        {
            ApplyVisuals(_playerVisuals.VisualsIndex);
            _playerVisuals.OnColorChanged += ApplyVisuals;
        }

        private void ApplyVisuals(byte visualsIndex)
        {
            _target.material = _materialTable.GetMaterial(visualsIndex);
        }
    }
}