using Student_details_api_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_details_api_core.Repositories
{
    public interface IStudentsRepository //describe operation perform against database
    {
        Task<IEnumerable<Students>> Get(); //all student

        Task<Students> Get(int id);//single student

        Task<Students> Create(Students Students);

        Task Update(Students Students);

        Task Delete(int id);
    }
}
