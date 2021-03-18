using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ControlPanel : MonoBehaviour
{
    public List<MonoBehaviour> scripts;
    public List<NavMeshAgent> agents;
    public bool isGamePaused = false;
    public GameObject pauseLabelPanel;

    public PlayerBehaviour player;
    public PlayerDataSO playerData;
    // Start is called before the first frame update
    void Start()
    {
        agents = FindObjectsOfType<NavMeshAgent>().ToList();

        foreach(var enemy in FindObjectsOfType<EnemyBehaviour>())
        {
            scripts.Add(enemy);
        }
        player = FindObjectOfType<PlayerBehaviour>();
        scripts.Add(player);
        scripts.Add(FindObjectOfType<CameraController>());

        LoadFromPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPauseButtonToggled()
    {
        isGamePaused = !isGamePaused;
        pauseLabelPanel.SetActive(isGamePaused);

        foreach (var script in scripts)
        {
            script.enabled = !isGamePaused;
        }

        foreach (var agent in agents)
        {
            agent.enabled = !isGamePaused;
        }
    }

    public void onLoadButtonPressed()
    {
        player.controller.enabled = false;
        player.transform.position = playerData.playerPosition;
        player.transform.rotation = playerData.playerRotation;
        player.health = playerData.playerHealth;
        player.controller.enabled = true;
    }

    public void onSaveButtonPressed()
    {
        playerData.playerPosition = player.transform.position;
        playerData.playerRotation = player.transform.rotation;
        playerData.playerHealth = player.health;
    }

    public void LoadFromPrefs()
    {
        playerData.playerPosition.x = PlayerPrefs.GetFloat("playerPositionX");
        playerData.playerPosition.y = PlayerPrefs.GetFloat("playerPositionY");
        playerData.playerPosition.z = PlayerPrefs.GetFloat("playerPositionZ");
                                    
        playerData.playerRotation.x = PlayerPrefs.GetFloat("playerRotationX");
        playerData.playerRotation.y = PlayerPrefs.GetFloat("playerRotationY");
        playerData.playerRotation.z = PlayerPrefs.GetFloat("playerRotationZ");

        playerData.playerHealth = PlayerPrefs.GetInt("PlayerHealth");
    }

    public void SaveToPrefs()
    {
        PlayerPrefs.SetFloat("playerPositionX", playerData.playerPosition.x);
        PlayerPrefs.SetFloat("playerPositionY", playerData.playerPosition.y);
        PlayerPrefs.SetFloat("playerPositionZ", playerData.playerPosition.z);

        PlayerPrefs.SetFloat("playerRotationX", playerData.playerRotation.x);
        PlayerPrefs.SetFloat("playerRotationY", playerData.playerRotation.y);
        PlayerPrefs.SetFloat("playerRotationZ", playerData.playerRotation.z);

        PlayerPrefs.SetInt("PlayerHealth", playerData.playerHealth);

        PlayerPrefs.Save();
    }
}
