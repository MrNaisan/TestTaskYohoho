using System;

namespace ECS.Objects
{
    [Serializable]
    public struct InitializeEntityRequest
    {
        public EntityReference entityReference;
    }
}