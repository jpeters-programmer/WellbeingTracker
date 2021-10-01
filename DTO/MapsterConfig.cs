using System.Reflection;
using Mapster;
using Model;

namespace Mapster
{
    public class ModelsCodeGenerationRegister : ICodeGenerationRegister
    {
        public void Register(CodeGenerationConfig config)
        {
            
            config.AdaptTo("[name]Dto")
            .ForType<Trackable>();

            config.GenerateMapper("[name]Mapper")
            .ForType<Trackable>();
        }
    }
}