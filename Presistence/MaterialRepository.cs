using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Core;
using E_Commerce.Core.Models;

namespace E_Commerce.Presistence
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ApplicationDbContext context;

        public MaterialRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddMaterial(Material material)
        {
            context.Materials.Add(material);
        }

        public async Task<Material> GetMaterialAsync(int id)
        {
            return await context.Materials.FindAsync(id);
        }

        public IEnumerable<Material> GetMaterials()
        {
            return context.Materials;
        }

        public void RemoveMaterial(Material material)
        {
            context.Materials.Remove(material);
        }
    }
}