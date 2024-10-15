using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Model
{
    public class LobbyLauncher : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _addressInputField;
        [SerializeField] private TMP_InputField _portInputField;
        [SerializeField] private Button _hostButton;
        [SerializeField] private Button _joinButton;
        
        [SerializeField] private NetworkManager _networkManager;

        private void Start()
        {
            PortTransport portTransport = Transport.active as PortTransport;

            if (portTransport == null)
            {
                return;
            }
            
            _addressInputField.text =  _networkManager.networkAddress;
            _portInputField.text =  portTransport.Port.ToString();
            
            _addressInputField.onSubmit.AddListener((newAddress => _networkManager.networkAddress = newAddress));
            _portInputField.onSubmit.AddListener(newPort =>
            {
                if (ushort.TryParse(newPort, out ushort transportPort))
                {
                    portTransport.Port = transportPort;
                }
            });
            _hostButton.onClick.AddListener(Host);
            _joinButton.onClick.AddListener(Join);
        }

        private void OnDestroy()
        {
            _addressInputField.onSubmit.RemoveAllListeners();
            _portInputField.onSubmit.RemoveAllListeners();
            _hostButton.onClick.RemoveAllListeners();
            _joinButton.onClick.RemoveAllListeners();
        }

        private void Host()
        {
            if (!NetworkServer.active)
            {
                _networkManager.StartHost();
            }
         
        }
        
        private void Join()
        {
            if (!NetworkClient.active)
            {
                _networkManager.StartClient();
            }
        }
    }
}