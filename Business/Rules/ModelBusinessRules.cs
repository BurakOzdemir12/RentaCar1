using DataAccess.Abstacts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class ModelBusinessRules
    {
        //product names can not be duplicated
        //we ask to database this questions like is there same model name?

        IModelDal _modelDal;
       
        
        public ModelBusinessRules(IModelDal modelDal) 
        {
        _modelDal = modelDal;
        }
        /**/
       
        
        public void ModelNameCanNotBeDuplicated(string modelName)
        {
            //we put a question mark cauese this can be null
            Model? model=_modelDal.Get(m=>m.Name ==modelName);

            if (model != null) {
                throw new Exception("Model Name already exists");
            }
        }
    }
}
