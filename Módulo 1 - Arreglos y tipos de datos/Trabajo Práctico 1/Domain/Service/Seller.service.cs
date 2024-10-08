﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Práctico_1.Domain.Datasource;
using Trabajo_Práctico_1.Domain.Models;
using Trabajo_Práctico_1.Infrastructure.Utils;

namespace Trabajo_Práctico_1.Domain.Service
{
    internal class SellerService
    {

        public  async Task<bool> CreateSellerAsync(int code, string name, decimal salary )
        {
            try {
                await Task.Delay(2000);

                if (SellerDatasource.totalSellers >= SellerDatasource.MAXIMUN_SELLERS)
                {
                    MessageBox.Show("Has alcanzado el máximo número de vendedores", "Límite de Vendedores",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //throw new InvalidOperationException("Error simulado para pruebas.");

                Seller.SellerStruct newSeller = Seller.createSeller(code, name, salary);

                SellerDatasource.sellers[SellerDatasource.totalSellers] = newSeller;

                SellerDatasource.totalSellers++;

                return true;
            }
            catch 
            {

                return false;
                
            }

        }

        public async Task<Seller.SellerStruct[]> GetAllSellerAsync(int sortField, int sortBy)
        {
            try
            {
                if (SellerDatasource.totalSellers == 0) return Array.Empty<Seller.SellerStruct>();
                        
                await Task.Delay(1000);
                
                switch (sortField)
                {
                    case Globals.COMBO_BOX_FIELD_CODE:
                        if(sortBy == Globals.COMBO_BOX_SORT_BY_ASC)
                        {
                            return SellerDatasource.SortByCodeAscSellers();
                        }
                        return SellerDatasource.SortByCodeDescSellers();
                    case Globals.COMBO_BOX_FIELD_NAME:
                        if (sortBy == Globals.COMBO_BOX_SORT_BY_ASC)
                        {
                            return SellerDatasource.SortByNameAscSellers();
                        }
                        return SellerDatasource.SortByNameDescSellers();
                    case Globals.COMBO_BOX_FIELD_SALARY:
                        if (sortBy == Globals.COMBO_BOX_SORT_BY_ASC)
                        {
                            return SellerDatasource.SortByCodeAscSellers();
                        }
                        return SellerDatasource.SortByCodeDescSellers();
                    default:
                        return SellerDatasource.sellers;
                        
                }                 
                 
            }
            catch
            {
                return Array.Empty<Seller.SellerStruct>();
            }
        }

        public async Task<Seller.SellerStruct?> GetSellerAsync(int code)
        {
            try
            {
                if (SellerDatasource.totalSellers == 0)
                {
                    return null;
                }

                // Simula un retraso para imitar operaciones asincrónicas si es necesario
                await Task.Delay(1000);

                // Busca el vendedor por código
                for (int i = 0; i < SellerDatasource.totalSellers; i++)
                {
                    if (SellerDatasource.sellers[i].code == code)
                    {
                        return SellerDatasource.sellers[i];
                    }
                }

                // Retorna null si no se encuentra el vendedor
                return null;
            }
            catch
            {
                // Puedes registrar el error o manejarlo de una manera específica si es necesario
                // Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }


    }
}
