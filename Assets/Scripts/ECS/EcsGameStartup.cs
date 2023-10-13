using ECS.PlayerMovment;
using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

public sealed class EcsGameStartup : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    
    private EcsWorld world;
    private EcsSystems systems;

    private void Start() 
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);    

        systems.ConvertScene();

        AddInjections();
        AddOnFrames();
        AddSystems();

        systems.Init();
    }

    private void AddInjections()
    {
        systems.Inject(joystick);
    }

    private void AddSystems()
    {
        systems
            .Add(new InputSystem())
            .Add(new MovmentSystem())
            .Add(new RotateSystem());
    }

    private void AddOnFrames()
    {
        
    }

    private void Update() 
    {
        systems.Run();    
    }

    private void OnDestroy() 
    {
        if(systems == null) return;

        systems.Destroy();
        systems = null;
        world.Destroy();
        world = null;    
    }
}