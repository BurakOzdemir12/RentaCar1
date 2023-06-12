using DataAccess.Repository;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstacts
{
    
    //interface can extend an interface
    public interface IModelDal:IEntityRepository<Model> //ımodeldal has the crud operations
    {
       //custom operations
       List<Model> GetAllWithBrand();
        List<Model> GetAllWithBrand(string modelName);
        
    }
}
