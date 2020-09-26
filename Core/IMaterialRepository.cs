using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Core.Models;

namespace E_Commerce.Core
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> GetMaterials();
        void AddMaterial(Material material);
        void RemoveMaterial(Material material);
        Task<Material> GetMaterialAsync(int id);
    }
}