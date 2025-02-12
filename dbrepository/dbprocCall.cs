using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbrepository
{
    public class dbprocCall
    {
        public List<Operation> getdata()
        {
            var listData=new List<Operation>();
            for (int i = 0; i < 10; i++)
            {
                var data = new Operation
                {
                    Id = i,
                    Name = "satya" + Convert.ToString(i)
                };
                listData.Add(data);

            }

            return listData;
        }
        public bool postData(Operation opsdt)
        {
            /// call here db call to update data.
            var paraval = opsdt;
            return true;

        }


    }
}
