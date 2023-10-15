using ECS.Objects;
using ECS.PlayerMovment;
using ECS.States;
using Pool;
using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

namespace ECS
{
    public sealed class EcsGameStartup : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private ObjectsPool objectsPool;
        
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
            systems
                .Inject(joystick)
                .Inject(objectsPool);
        }
    
        private void AddSystems()
        {
            systems
                .Add(new InitializeEntitySystem())
                .Add(new InputSystem())
                .Add(new MovmentSystem())
                .Add(new RotateSystem())
                .Add(new SpawnSystem())
                .Add(new BlockSystem())
                .Add(new StackSystem())
                .Add(new UnStackSystem())
                .Add(new StackChecker())
                .Add(new StateSystem());
        }
    
        private void AddOnFrames()
        {
            systems
                .OneFrame<IdleEvent>()
                .OneFrame<WalkEvent>()
                .OneFrame<HandsUpEvent>()
                .OneFrame<HandsDownEvent>();
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
}
