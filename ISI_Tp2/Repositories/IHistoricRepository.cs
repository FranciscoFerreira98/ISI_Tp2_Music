using System.Collections.Generic;
using ISI_Tp2.Models;

namespace ISI_Tp2.Repositories
{
    public interface IHistoricRepository
    {
        List<Historic> GetHistoricByIdUser(int userId);
        bool DeleteHistoricById(int id);
    }
}
