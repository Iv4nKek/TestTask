using UnityEngine;

namespace Code.View
{
    public class ColorPickerView : MonoBehaviour
    {
        [SerializeField] private MaterialTable _table;
        [SerializeField] private GameObject _colorLabelPrefab;
        [SerializeField] private Transform _root;

        private void Start()
        {
            for (var i = 0; i < _table.AvailableColors.Length; i++)
            {
                var material = _table.AvailableColors[i];
                GameObject newLabel = Instantiate(_colorLabelPrefab, _root);
                ColorLabelView colorLabelView = newLabel.GetComponent<ColorLabelView>();
                colorLabelView.Initialize(material.color, i+1);
            }
        }
    }
}