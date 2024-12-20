using Photon.Pun;
using UnityEngine;

namespace Kruty1918.Networking
{
    public class ConnectToServer : MonoBehaviour
    {
        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}