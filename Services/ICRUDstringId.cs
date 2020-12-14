﻿using razorHramBabynino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razorHramBabynino.Services
{
    public interface ICRUDstringId<Type>
    {
        List<Type> get();
        Type itemById(string id);
        void add(Type item);        
        void update(Type item);
        void delete(Type item);
        
        Task<List<Type>> getAsync();
        Task<Type> itemByIdAsync(string id);
        Task addAsync(Type item);
        Task updateAsync(Type item);
        Task deleteAsync(Type item);
    }
}
