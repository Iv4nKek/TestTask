using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.View
{
    public class ColorLabelView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _indexText;
        
        public void Initialize(Color color, int index)
        {
            _image.color = color;
            _indexText.text = index.ToString();
        }
    }
}