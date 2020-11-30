using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    [Header("Drop Down")]
    public Transform teamDrpDwn;
    public Transform ballSizeDrpDwn;
    public Transform inWaterDrpDwn;

    [Header("Canvas Text")]
    public Text sportTxt;

    [Header("Balls")]
    public GameObject golf;
    public GameObject waterPolo;
    public GameObject waterFootBall;
    public GameObject beachBall;
    public GameObject spikeBall;
    public GameObject volleyBall;
    public GameObject kinBall;
    public GameObject divingBall;
    public GameObject waterBasketBall;
    public GameObject waterBall;
    public GameObject bowlingBall;
    public GameObject yardPong;
    public BallSpawner spawner;

    private bool isTeam;
    private int ballSize;
    private bool inWater;

    public void SpawnSport()
    {
        int temp;
        temp = teamDrpDwn.GetComponent<Dropdown>().value;
        if (temp == 0) isTeam = true;
        else isTeam = false;

        ballSize = ballSizeDrpDwn.GetComponent<Dropdown>().value;

        temp = inWaterDrpDwn.GetComponent<Dropdown>().value;
        if (temp == 0) inWater = true;
        else inWater = false;

        SportRequirements requirements = new SportRequirements();
        requirements.isTeam = isTeam;
        requirements.ballSize = ballSize;
        requirements.inWater = inWater;

        ISport s = GetSport(requirements);
        sportTxt.text = s.ToString();

        if(s.ToString() == "Golf") spawner.SpawnBall(golf);
        else if(s.ToString() == "WaterPolo") spawner.SpawnBall(waterPolo);
        else if(s.ToString() == "WaterFootBall") spawner.SpawnBall(waterFootBall);
        else if(s.ToString() == "BeachBall") spawner.SpawnBall(beachBall);
        else if(s.ToString() == "SpikeBall") spawner.SpawnBall(spikeBall);
        else if(s.ToString() == "VolleyBall") spawner.SpawnBall(volleyBall);
        else if(s.ToString() == "KinBall") spawner.SpawnBall(kinBall);
        else if(s.ToString() == "DivingBall") spawner.SpawnBall(divingBall);
        else if(s.ToString() == "WaterBasketBall") spawner.SpawnBall(waterBasketBall);
        else if(s.ToString() == "WaterBall") spawner.SpawnBall(waterBall);
        else if(s.ToString() == "Bowling") spawner.SpawnBall(bowlingBall);
        else spawner.SpawnBall(yardPong);

    }

    private static ISport GetSport(SportRequirements requirements)
    {
        SportFactory factory = new SportFactory(requirements);
        return factory.Create();
    }
}
