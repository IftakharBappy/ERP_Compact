using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERP_Compact.Models;
namespace ERP_Compact.DAL
{
    public class ManageGIS
    {
        private ERPMgtEntities db = new ERPMgtEntities();
        public List<GISclass> ListAll()
        {
            List<GISclass> obj = new List<GISclass>();
            var temp = (from x in db.Division where x.IsDelete==false

                        select new GISclass
                        {
                            DivisionID = x.DivisionID,
                            DivisionKey= x.DivisionKey,
                            DivisionName = x.DivisionName,
                            IsDelete=x.IsDelete
                        }).OrderBy(m => m.DivisionName);
            obj = temp.ToList();
            return obj;
        }
        public int Add(GISclass obj)
        {
            int i = 1;
            try
            {
                Division model = new Division();
                model.DivisionKey = Guid.NewGuid();
                model.DivisionID = obj.DivisionID;
                model.DivisionName = obj.DivisionName;
                model.IsDelete = false;
                db.Division.Add(model);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                i = 0;
            }
            return i;
        }

        public int Update(GISclass obj)
        {
            int i = 1;
            try
            {
                Division model = db.Division.Find(obj.DivisionKey);
                model.DivisionID = obj.DivisionID;
                model.DivisionName = obj.DivisionName;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                i = 0;
            }
            return i;
        }

        public int Delete(Guid ID)
        {
            int i = 1;
            try
            {
                Division model = db.Division.Find(ID);
                model.IsDelete = true;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                i = 0;
            }
            return i;
        }
    }
}