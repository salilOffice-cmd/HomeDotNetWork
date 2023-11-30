using APIArchitectureWithRelations.Context;
using APIArchitectureWithRelations.Models;
using Microsoft.EntityFrameworkCore;

namespace APIArchitectureWithRelations.Data_Access_Layer
{
    public class FloorRepository : IFloorRepo
    {
        private readonly Company2DBContext context;
        public FloorRepository(Company2DBContext _context)
        {
            context = _context;
        }


        public async Task AddFloor_Repo(Floor floor)
        {
            await context.Floors.AddAsync(floor);
            await context.SaveChangesAsync();
        }

        public async Task<Floor> GetFloorSpecificEmployees_Repo(int floorId)
        {
            var floorAllEmployees = await context.Floors
                                          .Include(floor => floor.Employees)
                                          .Where(floor => floor.FloorId == floorId)
                                          .FirstOrDefaultAsync();

            return floorAllEmployees;
        }

    }
}
