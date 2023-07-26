﻿using Core.Entity.Abstract;
using Core.Utils;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Abstract
{
    public interface IService<TRequest,TResponse>  where TRequest : ISurrogate, new()
                                                   where TResponse : ISurrogate, new()
    {
       IDataResult<List<TResponse>> GetAll();
       IDataResult<TResponse> Get(int id);
       IResult Add(TRequest data);
       IResult Update(int id,TRequest data);
       IResult Delete(int id);

        

    }
}
