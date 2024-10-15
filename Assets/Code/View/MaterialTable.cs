using UnityEngine;

namespace Code.View
{
    [CreateAssetMenu]
    public class MaterialTable : ScriptableObject
    {
        [SerializeField] private Material[] _availableColors;

        public Material[] AvailableColors => _availableColors;

        public Material GetMaterial(int index)
        {
            return _availableColors[index];
        }
    }
}