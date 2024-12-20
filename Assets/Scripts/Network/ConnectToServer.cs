using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kruty1918.Networking
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            SceneManager.LoadScene("Lobby");
        }
    }
}