using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Data
{
    public class DL
    {
        MasterEntities db = new MasterEntities();

        public Teacher checkUsername(string username)
        {
            var records = db.Teacher;

            var recordsQuery =
                from record in records
                where record.Username == username
                select record;

            return recordsQuery.SingleOrDefault();
        }

        public Teacher logIn(string username, string password)
        {
            var records = db.Teacher;

            var recordsQuery =
                from record in records
                where record.Username == username && record.Password == password
                select record;

            return recordsQuery.SingleOrDefault();
        }

        public List<Group> DisplayGroups()
        {
            var records = db.Group;

            var recordsQuery =
                from record in records
                select record;

            List<Group> groups = new List<Group>();

            foreach (var record in recordsQuery)
            {
                groups.Add(record);
            }

            return groups;
        }
    }
}
