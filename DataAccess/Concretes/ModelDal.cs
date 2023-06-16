using Core.DataAccess;
using DataAccess.Abstacts;
using DataAccess.Contexts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class ModelDal : EfEntityRepositoryBase<Model, RentaCarContext>, IModelDal

    {
        public List<Model> GetAllWithBrand()
        {
           using (RentaCarContext context = new RentaCarContext()) 
            {
            return context.Models.Include(m => m.Brand).ToList();   
            
            }
        }

        public List<Model> GetAllWithBrand(string modelName)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                return context.Models.Include(m => m.Brand).Where(m => m.Name.ToLower().Contains( modelName.ToLower())).ToList();


            }
        }
    }
}
