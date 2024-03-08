using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerObstacleDatabase", menuName = "PlayerObsrtacle/Skins shop database")]
public class PlayerObstacleSkinDatabase : ScriptableObject
{
    public PlayerObstacleSkin[] skins;

    public int SkinsCount{
        get{
            return skins.Length;
        }
    }

    public PlayerObstacleSkin GetSkin (int index){
        return skins[index];
    }

    public Sprite GetObstacle(int index){
        return skins[index].obstacle;
    }

}
