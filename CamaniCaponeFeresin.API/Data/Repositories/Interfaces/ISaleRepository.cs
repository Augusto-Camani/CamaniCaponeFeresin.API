﻿using CamaniCaponeFeresin.API.Entities;

namespace CamaniCaponeFeresin.API.Data.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        public IEnumerable<Sale> GetAll();
        public IEnumerable<Sale> GetSalesByClientId(int clientId);
        public Sale GetSaleBy(int id);
    }
}