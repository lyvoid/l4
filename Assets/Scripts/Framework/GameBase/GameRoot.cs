using UnityEngine;
using GameSystem;

public class GameRoot : MonoBehaviour
{
    public static GameRoot Ins { private set; get; }

    private readonly ISystem[] _systems = {
        GameEventSystem.Ins,
        ResSystem.Ins,
        SceneSystem.Ins,
        UISystem.Ins,
    };

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    public void Start()
    {
        Ins = this;
        // initial System
        foreach (var system in _systems)
        {
            system.Initialize();
        }
    }

    // Update is called once per frame
    public void Update()
    {
        foreach (var system in _systems)
        {
            system.Update();
        }
    }

    public void BeforeSceneLoaded()
    {
        foreach (var system in _systems)
        {
            system.BeforeSceneLoaded();
        }
    }

    public void AfterSceneDestoryed()
    {
        foreach (var system in _systems)
        {
            system.AfterSceneDestoryed();
        }
    }

    public void BeforeSceneDestoryed()
    {
        foreach (var system in _systems)
        {
            system.BeforeSceneDestoryed();
        }
    }

    public void AfterSceneLoaded()
    {
        foreach (var system in _systems)
        {
            system.AfterSceneLoaded();
        }
    }
}

