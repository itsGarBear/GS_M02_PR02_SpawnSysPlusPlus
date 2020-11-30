using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISportFactory
{
    ISport Create(SportRequirements requirements);
}

public class SmallBallSportFactory : MonoBehaviour, ISportFactory
{
    public ISport Create(SportRequirements requirements)
    {
        if (requirements.isTeam)
        {
            if (requirements.inWater)
            {
                return new WaterPolo();
            }
            else return new SpikeBall();
        }
        else
        {
            if (requirements.inWater) return new DivingBall();
            else return new Golf();
        }
    }
}

public class MedBallSportFactory : MonoBehaviour,  ISportFactory
{
    public ISport Create(SportRequirements requirements)
    {
        if (requirements.isTeam)
        {
            if (requirements.inWater) return new WaterFootBall();
            else return new VolleyBall();
        }
        else
        {
            if (requirements.inWater) return new WaterBasketBall();
            else return new Bowling();
        }
    }
}

public class LargeBallSportFactory : MonoBehaviour, ISportFactory
{
    public ISport Create(SportRequirements requirements)
    {
        if (requirements.isTeam)
        {
            if (requirements.inWater) return new BeachBall();
            else return new KinBall();
        }
        else
        {
            if (requirements.inWater) return new WaterBall();
            else return new YardPong();
        }
    }
}

/*public class TeamSportFactory : ISportFactory
{
    public ISport Create(SportRequirements requirements)
    {
        if (requirements.inWater)
        {
            if (requirements.ballSize == 0) return new WaterPolo();
            if (requirements.ballSize == 1) return new WaterFootBall();
            else return new BeachBall();
        }
        else
        {
            if (requirements.ballSize == 0) return new SpikeBall();
            if (requirements.ballSize == 1) return new VolleyBall();
            else return new KinBall();
        }
        
    }
}*/

/*public class SoloSportFactory : ISportFactory
{
    public ISport Create(SportRequirements requirements)
    {
        if (requirements.inWater)
        {
            if (requirements.ballSize == 0) return new DivingBall();
            if (requirements.ballSize == 1) return new WaterBasketBall();
            else return new WaterBall();
        }
        else
        {
            if (requirements.ballSize == 0) return new Golf();
            if (requirements.ballSize == 1) return new Bowling();
            else return new YardPong();
        }
    }
}*/

public abstract class AbstractSportFactory
{
    public abstract ISport Create();
}

public class SportFactory : AbstractSportFactory
{
    private readonly ISportFactory _factory;
    private readonly SportRequirements _requirements;

    public SportFactory(SportRequirements requirements)
    {
        if (requirements.ballSize == 0) _factory = (ISportFactory) new SmallBallSportFactory();
        else if (requirements.ballSize == 1) _factory = (ISportFactory) new MedBallSportFactory();
        else _factory = (ISportFactory) new LargeBallSportFactory();
        _requirements = requirements;
    }

    public override ISport Create()
    {
        return _factory.Create(_requirements);
    }
}
