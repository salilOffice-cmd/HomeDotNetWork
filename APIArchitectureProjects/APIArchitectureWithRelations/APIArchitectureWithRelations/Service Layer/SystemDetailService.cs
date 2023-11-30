using APIArchitectureWithRelations.Data_Access_Layer;

namespace APIArchitectureWithRelations.Service_Layer
{
    public class SystemDetailService : ISystemDetailService
    {
        private readonly ISystemDetailRepo systemDetailsRepo;
        public SystemDetailService(ISystemDetailRepo _systemDetailsRepo)
        {
            systemDetailsRepo = _systemDetailsRepo;
        }
    }
}
