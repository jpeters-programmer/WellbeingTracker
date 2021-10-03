using System.Reflection;
using Mapster;
using Model;

namespace Mapster
{
    public class ModelsCodeGenerationRegister : ICodeGenerationRegister
    {
        public void Register(CodeGenerationConfig config)
        {            
            var types = new [] {typeof(User), typeof(Trackable), typeof(TrackedItem), typeof(TrackingSetup), typeof(TrackingEntry)};
            config.AdaptTo("[name]Dto").ForTypes(types);            
            config.GenerateMapper("[name]Mapper").ForTypes(types);
        }
    }
}