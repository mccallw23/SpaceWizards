using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Player : RealtimeComponent<PlayerModel>
{
    public string playerName;
    public int playerHealth;
    public PlayerModel _model;



    private void Awake()
    {
        playerName = "Name not set";
        playerHealth = 10;
        print("Hello?");
    }

    protected override void OnRealtimeModelReplaced(PlayerModel previousModel, PlayerModel currentModel)
    {
        print("Realtime model repleaced");

        if (previousModel != null)
        {
            print("Previous model not null");
            // Unregister from events
            previousModel.nameDidChange -= NameDidChange;
            previousModel.healthDidChange -= HealthDidChange;
        }

        if (currentModel != null)
        {
            print("Current model not null");
            // If this is a model that has no data set on it, populate it with current stats.
            if (currentModel.isFreshModel)
            {
                currentModel.health = playerHealth;
                currentModel.name = playerName;
            }
               

            // Register for events so we'll know if the anything changes later
            currentModel.nameDidChange += NameDidChange;
            currentModel.healthDidChange += HealthDidChange;
            _model = currentModel;
            print("current model");
            print(_model);
        }
    }


    // fires when health on model has changed
    private void HealthDidChange(PlayerModel model, int value)
    {
        // Update the health
        UpdateHealth();
    }


    // fires when name on model has changed
    private void NameDidChange(PlayerModel model, string name)
    {
        UpdateName();
    }


    // changes health on this player script
    private void UpdateHealth()
    {
        playerHealth = _model.health;
    }


    // changes name on this player script
    private void UpdateName()
    {
        if (_model != null)
        {
            playerName = _model.name;
        }
        
    }


    // can set name of model
    public void SetName(string name)
    {
        print(_model);
            _model.name = name;
        
    }


    // can set health of model
    public void SetHealth(int health)
    {
            _model.health = health;
        
    }
}
