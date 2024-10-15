using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Model
{
    public class ColorPicker : MonoBehaviour
    {
         [SerializeField] private InputActionReference _colorInput1;
         [SerializeField] private InputActionReference _colorInput2;
         [SerializeField] private InputActionReference _colorInput3;
         [SerializeField] private InputActionReference _colorInput4;

        [SerializeField] private PlayerVisuals _playerVisuals;

        private void Start()
        {
            _colorInput1.action.performed += SetColor1;
            _colorInput2.action.performed += SetColor2;
            _colorInput3.action.performed +=SetColor3;
            _colorInput4.action.performed += SetColor4;
        }
        
        private void SetColor1(InputAction.CallbackContext context) => _playerVisuals.SetColor(0);
        private void SetColor2(InputAction.CallbackContext context) => _playerVisuals.SetColor(1);
        private void SetColor3(InputAction.CallbackContext context) => _playerVisuals.SetColor(2);
        private void SetColor4(InputAction.CallbackContext context) => _playerVisuals.SetColor(3);

        private void OnDestroy()
        {
            _colorInput1.action.performed -= SetColor1;
            _colorInput2.action.performed -= SetColor2;
            _colorInput3.action.performed -= SetColor3;
            _colorInput4.action.performed -= SetColor4;
        }
    }
}