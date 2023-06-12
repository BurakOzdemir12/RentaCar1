using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IModelService
    {
        //Overloading
        List<GetModelResponse> GetAll();
        List<GetModelResponse> GetAll(string modelName);
       
        void Add(CreateModelRequest createModelRequest);
        
        void Update(CreateModelRequest createModelRequest);
        void Delete(CreateModelRequest createModelRequest);
         
        //GetAllByName; 
    }
}
