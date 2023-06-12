using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.Rules;
using DataAccess.Abstacts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    //dependency injection
    public class ModelManager :IModelService
    {
        private IModelDal _modelDal;
        ModelBusinessRules rules;
        public ModelManager(IModelDal modelDal) // model dal doesnt know who sql oracle is
        {
            _modelDal = modelDal;
            rules = new ModelBusinessRules(_modelDal);
        }
         
        public void Add(CreateModelRequest createModelRequest)
        {
            
            //product names can not be duplicated
            //when we use another method like update we must be able to use same rule
            // So We include our rules different folders
            //business rules
          
            rules.ModelNameCanNotBeDuplicated(createModelRequest.Name);
           

            //mapping
            Model model = new Model
            {
              Name=  createModelRequest.Name,
              Description= createModelRequest.Description,
              UnitPrice= createModelRequest.UnitPrice,
              BrandId=createModelRequest.BrandId,
               
            };

            _modelDal.Add(model);
            
        }
        /* */

        public void Delete(CreateModelRequest createModelRequest)
        {
            Model model = new Model
            {
                Name = createModelRequest.Name,
                Description = createModelRequest.Description,
                UnitPrice = createModelRequest.UnitPrice,
                BrandId = createModelRequest.BrandId,
                
            };
            _modelDal.Delete(model);
        }

        // never make an instance in a business layer for dal layer
        // ModelDal modelDal=new ModelDal();

       

        public void Update(CreateModelRequest createModelRequest)
        {
            rules.ModelNameCanNotBeDuplicated(createModelRequest.Name);

            Model model = new Model
            {
                Name = createModelRequest.Name,
                Description = createModelRequest.Description,
                UnitPrice = createModelRequest.UnitPrice,
                BrandId = createModelRequest.BrandId,
            };
            
            _modelDal.Update(model);
        }
        

        public List<GetModelResponse> GetAll()
        {
            List<Model> models =_modelDal.GetAllWithBrand().ToList();
            List<GetModelResponse> getModelResponses = new List<GetModelResponse>();
       foreach (Model model in models)
            {
                GetModelResponse getModelResponse = new GetModelResponse();
                getModelResponse.Name = model.Name;
                getModelResponse.Description = model.Description;
                getModelResponse.UnitPrice = model.UnitPrice;
                getModelResponse.Id = model.Id; 
                getModelResponse.BrandId= model.BrandId;
                getModelResponse.BrandName=model.Brand.Name;

                getModelResponses.Add(getModelResponse);
                
            }
            return getModelResponses;
        }

        public List<GetModelResponse> GetAll(string modelName)
        {
            List<Model> models  = _modelDal.GetAllWithBrand(modelName).ToList();
            List<GetModelResponse> getModelResponses = new List<GetModelResponse>();
            foreach (Model model in models)
            {
                GetModelResponse getModelResponse = new GetModelResponse();
                getModelResponse.Name = model.Name;
                getModelResponse.Description = model.Description;
                getModelResponse.UnitPrice = model.UnitPrice;
                getModelResponse.Id = model.Id;
                getModelResponse.BrandId = model.BrandId;
                getModelResponse.BrandName = model.Brand.Name;

               getModelResponses.Add(getModelResponse);
                
            }
            return getModelResponses;
        }

    }
}
