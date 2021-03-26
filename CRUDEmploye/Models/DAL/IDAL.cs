using CRUDEmploye.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEmploye.Models.DAL
{
    public interface IDAL
    {
        Employe GetEntityFromDataRow(DataRow dataRow);
        List<Employe> GetListFromDataTable(DataTable dataTable);
        void Add(Employe employe);
        void Update(int Id, Employe employe);
        void Delete(int Id);
        Employe SelectById(int Id);
        List<Employe> SelectAll();
    }
}
