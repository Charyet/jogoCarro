using Photon.Pun.Demo.SlotRacer;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField]TextMeshProUGUI textVitoria;
    public static GameManager Instance;
    [SerializeField]  GameObject PanelVitoria;
    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }

        Time.timeScale = 1f;
    }
    [PunRPC]
    public void FimDeJogo() 
    {
        if (photonView.IsMine)
        {
            textVitoria.text = "Você ganhou! :)"; 
        }
        else
        {
            textVitoria.text = "Você Perdeu! :(";
        }
        PanelVitoria.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartGame() 
    {
        SceneManager.LoadScene("Menu");
    }

    const string playerPrefabPath = "Prefabs/Carro";

    int playersInGame;
    List<Correndo1> playerList = new List<Correndo1>();
    Correndo1 playerLocal;

    private void Start()
    {
        photonView.RPC("AddPlayer", RpcTarget.AllBuffered);
    }
    private void CreatePlayer()
    {
        Correndo1 player = NetworkManager.instance.Instantiate(playerPrefabPath, new Vector3(-7, 0, 0), Quaternion.identity).GetComponent<Correndo1>();
        player.photonView.RPC("Initialize", RpcTarget.All);
    }

    [PunRPC]
    private void AddPlayer()
    {
        playersInGame++;
        if (playersInGame == PhotonNetwork.PlayerList.Length)
        {
            CreatePlayer();
        }
    }
}
